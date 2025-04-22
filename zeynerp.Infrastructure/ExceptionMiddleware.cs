using Microsoft.AspNetCore.Http;
using zeynerp.Core.Exceptions;

namespace zeynerp.Infrastructure
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                if (ex is EntityNotFoundException)
                    context.Response.Redirect($"/Error/EntityNotFound");
                
            }
        }
    }
}