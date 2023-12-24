using AutoMapper;
using MailKit.Net.Smtp;
using MailKit.Security;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;
using QRCoder;
using System.Drawing;
using System.Text.Json;

namespace metallenium_backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSender : ControllerBase
    {
        private readonly IConfirmedTicketService _confirmedTicketService;
        private readonly IUserService _userService;
        private readonly IPlaceService _placeService;

        public EmailSender(IConfirmedTicketService confirmedTicketService, IUserService userService, IPlaceService placeService)
        {
            _confirmedTicketService = confirmedTicketService;
            _userService = userService;
            _placeService = placeService;
        }



        [HttpPost]
        public async Task<ActionResult> SendEmail(TicketDto ticketDto)
        {
            // Convert TicketDto to a string
            string ticketInfoJson = JsonSerializer.Serialize(ticketDto);

            var user = await _userService.GetUserById(ticketDto.UserId);
            string userEmail = user.UserEmail;

            var place = await _placeService.GetPlaceById(ticketDto.PlaceId);
            string address = place.Address;
            string date = place.Date.ToString();

            ConfirmedTicketDto confirmedTicketDto = new();
            confirmedTicketDto.ConfirmedTicketId = 0;
            confirmedTicketDto.TicketId = ticketDto.TicketId;

            var confirmedTicket = await _confirmedTicketService.CreateConfirmedTicket(confirmedTicketDto);
            if(confirmedTicket == null)
            {
                throw new KeyNotFoundException($"User can book only one ticket");
            }
            // Создаем QR-код
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(ticketInfoJson, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Конвертируем изображение в поток
            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;

            // Создаем MIME-сообщение
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("")); // Укажите вашу почту
            email.To.Add(MailboxAddress.Parse(userEmail)); // Укажите адрес получателя
            email.Subject = "Metallenium. Your ticket has been confirmed!";

            // Создаем текстовую часть сообщения
            var textPart = new TextPart(TextFormat.Plain)
            {
                Text = "Your ticket reservation has been confirmed!" +
                " We are waiting for you at " + address + " " + date + " to make payment."
            };

            // Создаем вложение с изображением QR-кода
            var qrCodeAttachment = new MimePart("image", "png")
            {
                Content = new MimeContent(stream),
                ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                ContentTransferEncoding = ContentEncoding.Base64,
                FileName = "qrcode.png"
            };

            // Добавляем вложение к сообщению
            var multipart = new Multipart("mixed");
            multipart.Add(textPart);
            multipart.Add(qrCodeAttachment);
            email.Body = multipart;

            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.Auto);

            smtp.Authenticate("", ""); // Укажите ваши учетные данные
            smtp.Send(email);
            smtp.Disconnect(true);


            return Ok(confirmedTicketDto);
        }

    }
}
