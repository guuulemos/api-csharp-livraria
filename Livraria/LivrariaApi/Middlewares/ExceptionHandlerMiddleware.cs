using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace LivrariaApi.Middlewares
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception e)
            {
                await HandleException(context, e);
            }
        }

        private static Task HandleException(HttpContext context, Exception exception)
        {
            var codigo = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new
            {
                Codigo = codigo,
                Tipo = exception.GetType().Name,
                Erro = exception.Message,
                Detalhes = exception.StackTrace
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) codigo;
            return context.Response.WriteAsync(result);

        }
    }
}
