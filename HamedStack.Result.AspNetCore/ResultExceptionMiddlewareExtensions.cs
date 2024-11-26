using Microsoft.AspNetCore.Builder;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Extension methods for registering the ResultExceptionMiddleware in the application's middleware pipeline.
/// </summary>
public static class ResultExceptionMiddlewareExtensions
{
    /// <summary>
    /// Adds the ResultException middleware to the application's request pipeline.
    /// </summary>
    /// <param name="builder">The IApplicationBuilder instance.</param>
    /// <returns>The modified IApplicationBuilder instance.</returns>
    public static IApplicationBuilder UseResultException(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ResultExceptionMiddleware>();
    }
}
