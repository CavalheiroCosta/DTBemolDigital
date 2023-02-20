using Customer.Domain.Constants;
using Customer.Domain.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Refit;
using Serilog;
using static System.Net.Mime.MediaTypeNames;

namespace Customer.Domain.Handler
{
    public static class ExceptionHandler
    {
        public static void AddExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(exceptionHandlerApp =>
            {
                exceptionHandlerApp.Run(async context =>
                {
                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionFeature != null)
                    {
                        var httpStatusCode = exceptionFeature.Error switch
                        {
                            DomainException => StatusCodes.Status400BadRequest,
                            ExternalAddressNotFoundException => StatusCodes.Status404NotFound,
                            EntityNotFoundException => StatusCodes.Status404NotFound,
                            ApiException => StatusCodes.Status503ServiceUnavailable,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.Error(ConfigurationErrorMessages.ExceptionError(exceptionFeature.Error.Message));
                        context.Response.StatusCode = httpStatusCode;
                        context.Response.ContentType = Text.Plain;
                        await context.Response.WriteAsync(exceptionFeature.Error.Message);
                    }
                });
            });
        }
    }
}
