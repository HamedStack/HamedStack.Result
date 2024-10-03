// ReSharper disable UnusedType.Global

using System.Diagnostics;
using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Middleware for handling exceptions and transforming them into Result objects.
/// </summary>
public class ResultExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ResultExceptionMiddleware> _logger;
    private readonly IWebHostEnvironment _env;

    /// <summary>
    /// Initializes a new instance of the <see cref="ResultExceptionMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the request pipeline.</param>
    /// <param name="logger">The logger instance used for logging exceptions.</param>
    /// <param name="env">The hosting environment to determine the environment mode (Development, Production, etc.).</param>
    public ResultExceptionMiddleware(RequestDelegate next, ILogger<ResultExceptionMiddleware> logger, IWebHostEnvironment env)
    {
        _next = next;
        _logger = logger;
        _env = env;
    }

    /// <summary>
    /// Processes a request to determine if it matches a known exception, and if so, produces an error response.
    /// </summary>
    /// <param name="context">The context for the current request.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);

            var errorMessage = _env.IsDevelopment() ? ex.Message : "An unexpected error occurred on the server.";
            var error = new Error(errorMessage, ErrorType.Failure);
            var result = Result.Failure(error);

            var traceId = Activity.Current?.Id ?? context.TraceIdentifier;
            result.AddOrUpdateMetadata("TraceId", traceId);
            
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(JsonSerializer.Serialize(result));
        }
    }
}