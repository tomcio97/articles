using System;
using System.Threading.Tasks;
using Articles.Application.Exceptions;
using Microsoft.AspNetCore.Http;

namespace Articles.Application.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(BadRequestException exception)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(exception.Message);
            }
            catch(NotFoundException exception)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(exception.Message);
            }
            catch(Exception e)
            {
                context.Response.StatusCode = 500;
            }
        }
    }
}
