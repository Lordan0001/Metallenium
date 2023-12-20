using AutoMapper;
using metallenium_backend.Application.Interfaces.Repository;
using metallenium_backend.Application.Interfaces.Service;
using metallenium_backend.Domain.Dto;
using metallenium_backend.Domain.Models;
using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;



namespace metallenium_backend.Application
{
    public class ConfirmedTicketService : IConfirmedTicketService
    {
        private readonly IConfirmedTicketRepository _confirmedTicketRepository;
        private readonly IMapper _mapper;

        public ConfirmedTicketService(IConfirmedTicketRepository confirmedTicketRepository, IMapper mapper)
        {
            _confirmedTicketRepository = confirmedTicketRepository;
            _mapper = mapper;
        }

        public async Task<List<ConfirmedTicketDto>> GetAllConfirmedTickets()
        {
            var confirmedTickets = await _confirmedTicketRepository.GetAllConfirmedTickets();
            return _mapper.Map<List<ConfirmedTicketDto>>(confirmedTickets);
        }

        public async Task<ConfirmedTicketDto> GetConfirmedTicketById(int id)
        {
            var confirmedTicket = await _confirmedTicketRepository.GetConfirmedTicketById(id);
            if (confirmedTicket == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket with ID {id} not found.");
            }
            return _mapper.Map<ConfirmedTicketDto>(confirmedTicket);
        }

        public async Task<ConfirmedTicketDto> CreateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var confirmedTicket = _mapper.Map<ConfirmedTicket>(confirmedTicketDto);
            var createdConfirmedTicket = await _confirmedTicketRepository.CreateConfirmedTicket(confirmedTicket);
            return _mapper.Map<ConfirmedTicketDto>(createdConfirmedTicket);
        }

      /*  public async Task<ConfirmedTicketDto> SendEmail(UserDto userDto)
        {
            *//* var confirmedTicket = _mapper.Map<ConfirmedTicket>(confirmedTicketDto);
             var createdConfirmedTicket = await _confirmedTicketRepository.CreateConfirmedTicket(confirmedTicket);
             return _mapper.Map<ConfirmedTicketDto>(createdConfirmedTicket);*//*
            // Создаем QR-код
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(body, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            // Конвертируем изображение в поток
            MemoryStream stream = new MemoryStream();
            qrCodeImage.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            stream.Position = 0;

            // Создаем MIME-сообщение
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("metalleniumofficial@gmail.com")); // Укажите вашу почту
            email.To.Add(MailboxAddress.Parse("hyzerki@gmail.com")); // Укажите адрес получателя
            email.Subject = "Test email Subject";

            // Создаем текстовую часть сообщения
            var textPart = new TextPart(TextFormat.Html) { Text = body };

            // Создаем вложение с изображением QR-кода
            var qrCodeAttachment = new MimePart("image", "png")
            {
                Content = new MimeContent(stream),
                ContentDisposition = new MimeKit.ContentDisposition(ContentDisposition.Attachment),
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

            smtp.Authenticate("metalleniumofficial@gmail.com", "fsclgzvdmkoeukan"); // Укажите ваши учетные данные
            smtp.Send(email);
            smtp.Disconnect(true);

            return Ok();


        }*/

        public async Task<ConfirmedTicketDto> UpdateConfirmedTicket(ConfirmedTicketDto confirmedTicketDto)
        {
            var confirmedTicket = _mapper.Map<ConfirmedTicket>(confirmedTicketDto);
            var updatedConfirmedTicket = await _confirmedTicketRepository.UpdateConfirmedTicket(confirmedTicket);
            return _mapper.Map<ConfirmedTicketDto>(updatedConfirmedTicket);
        }

        public async Task<ConfirmedTicketDto> DeleteConfirmedTicket(int id)
        {
            var deletedConfirmedTicket = await _confirmedTicketRepository.DeleteConfirmedTicket(id);
            if (deletedConfirmedTicket == null)
            {
                throw new KeyNotFoundException($"ConfirmedTicket with ID {id} not found.");
            }
            return _mapper.Map<ConfirmedTicketDto>(deletedConfirmedTicket);
        }
    }

}
