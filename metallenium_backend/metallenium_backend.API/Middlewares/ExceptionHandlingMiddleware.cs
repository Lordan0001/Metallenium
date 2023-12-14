using metallenium_backend.Domain.Dto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;

namespace metallenium_backend.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;


        public ExceptionHandlingMiddleware(
            RequestDelegate next,
            ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);

            }
            catch (KeyNotFoundException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound,
                    "Requested object not found");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.NotFound,
                    "Db Update Concurrency Exception");
            }
            catch (UnauthorizedAccessException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.Unauthorized,
                    "Access to the requested resource is unauthorized");
            }
            catch (ValidationException ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.BadRequest,
                    "Validation Exception");
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex.Message, HttpStatusCode.InternalServerError,
                    "Internal Server Error");
            }

        }
        public async Task HandleExceptionAsync(HttpContext context, string exMsg, HttpStatusCode httpStatusCode, string message)
        {
            _logger.LogError(exMsg);

            HttpResponse response = context.Response;

            response.ContentType = "application/json";
            response.StatusCode = (int)httpStatusCode;

            ErrorDto errorDto = new()
            {
                Message = message,
                StatusCode = (int)httpStatusCode
            };

            string result = JsonSerializer.Serialize(errorDto);
            await response.WriteAsync(result);

        }
    }
}
