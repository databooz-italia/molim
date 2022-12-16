using Molim.Backend.API.DTO.Errors;
using Molim.Backend.API.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Molim.Backend.API.BusinessLayer.Exceptions;

namespace Molim.Backend.API.Middlewares
{
    public static class ExceptionsHandlerMiddleware
    {
        public static void UseManagedExceptionHandler(this IApplicationBuilder app, ILogger logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (contextFeature?.Error != null)
                    {
                        string errorCode = null;
                        string errorDescription = null;

                        if (contextFeature.Error is ManagedException)
                        {
                            errorCode = (contextFeature.Error as ManagedException).Code;
                            errorDescription = (contextFeature.Error as ManagedException).Description;
                        }

                        if (contextFeature.Error is BusinessManagedException)
                        {
                            errorCode = (contextFeature.Error as BusinessManagedException).Code;
                            errorDescription = (contextFeature.Error as BusinessManagedException).Description;
                        }

                        if (contextFeature.Error is DataManagedException)
                        {
                            errorCode = (contextFeature.Error as DataManagedException).Code;
                            errorDescription = (contextFeature.Error as BusinessManagedException).Description;
                        }

                        if (errorCode == null)
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        else
                            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                        logger.LogError(contextFeature?.Error, $"ERROR {errorCode} {errorDescription}");

                        context.Response.ContentType = "application/json";

                        await context.Response.WriteAsync(
                            JsonConvert.SerializeObject(new ErrorResponse()
                            {
                                Errors = new List<ErrorObject>() { new ErrorObject() { Code = errorCode, Description = errorDescription } }
                            }));
                    }

                });
            });
        }
    }
}
