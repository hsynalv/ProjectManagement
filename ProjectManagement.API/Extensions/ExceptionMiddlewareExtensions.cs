using Microsoft.AspNetCore.Diagnostics;
using ProjectManagement.Contracts;
using ProjectManagement.Entities.ErrorModel;
using ProjectManagement.Entities.Exceptions;

namespace ProjectManagement.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerManager logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    context.Response.StatusCode = contextFeature.Error switch
                    {
                        NotFoundException => StatusCodes.Status404NotFound,
                        _ => StatusCodes.Status500InternalServerError
                    };
                    logger.LogError("There is a problem : " + contextFeature.Error);
                    await context.Response.WriteAsync(new ErrorDetail
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = contextFeature.Error.Message
                    }.ToString());
                }
            });
        });
    }
}