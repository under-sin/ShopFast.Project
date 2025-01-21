using System.Net;
using Communication.Exceptions;
using Communication.Responses;
using Microsoft.AspNetCore.Diagnostics;

namespace Web.API.Handlers;

public class GlobalExceptionHandler : IExceptionHandler {
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken) {
        if (exception is ShopFastException shopFastException)
            await HandlerCustomException(shopFastException, httpContext, cancellationToken);
        else
            await UnkwnonExceptionHandler(exception, httpContext, cancellationToken);

        return true;
    }

    private static async Task HandlerCustomException(ShopFastException customException, HttpContext httpContext, CancellationToken cancellationToken) {
        if (customException is OnErrorValidationException onErrorValidationException) {
            httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await httpContext.Response
                .WriteAsJsonAsync(new ResponseErrorJson(onErrorValidationException.ErrorMessages), cancellationToken);
        }

        if (customException is NotFoundException notFoundException) {
            httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await httpContext.Response.WriteAsJsonAsync(new ResponseErrorJson(notFoundException.Message), cancellationToken);
        }
    }

    private static async Task UnkwnonExceptionHandler(Exception exception, HttpContext httpContext, CancellationToken cancellationToken) {
        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await httpContext.Response
            .WriteAsJsonAsync(new ResponseErrorJson(["Unkwnon Internal Error.", exception.Message]), cancellationToken);
    }
}
