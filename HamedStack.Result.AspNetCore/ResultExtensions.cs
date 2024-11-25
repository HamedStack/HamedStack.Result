// ReSharper disable UnusedMember.Global

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Provides extension methods for the Result classes for ASP.NET Core functionality.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Transforms a Result instance into an IActionResult.
    /// </summary>
    /// <param name="result">The Result instance.</param>
    /// <returns>The transformed IActionResult.</returns>
    public static IActionResult ToActionResult(this Result result)
    {
        return result.Status switch
        {
            ResultStatus.Success => new OkResult(),
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Transforms a Result&lt;T&gt; instance into an IActionResult.
    /// </summary>
    /// <param name="result">The Result&lt;T&gt; instance.</param>
    /// <returns>The transformed IActionResult.</returns>
    public static IActionResult ToActionResult<T>(this Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => new OkResult(),
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Transforms a PagedResult&lt;T&gt; instance into an IActionResult.
    /// </summary>
    /// <param name="result">The PagedResult&lt;T&gt; instance.</param>
    /// <returns>The transformed IActionResult.</returns>
    public static IActionResult ToActionResult<T>(this PagedResult<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => new OkResult(),
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result"/> instance to an appropriate <see cref="IResult"/> for Minimal APIs.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult"/> corresponding to the status of the <paramref name="result"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown when the result status is unknown or unsupported.</exception>
    public static IResult ToMinimalApiResult<T>(this Result result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Results.Ok(result),
            ResultStatus.Failure => Results.BadRequest(result),
            ResultStatus.Forbidden => Results.Forbid(),
            ResultStatus.Unauthorized => Results.Unauthorized(),
            ResultStatus.Invalid => Results.BadRequest(result),
            ResultStatus.NotFound => Results.NotFound(result),
            ResultStatus.Conflict => Results.Conflict(result),
            ResultStatus.Unsupported => Results.Json(result, statusCode: 501),
            ResultStatus.Unavailable => Results.Json(result, statusCode: 503),
            ResultStatus.ValidationError => Results.BadRequest(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to an appropriate <see cref="IResult"/> for Minimal APIs.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult"/> corresponding to the status of the <paramref name="result"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown when the result status is unknown or unsupported.</exception>
    public static IResult ToMinimalApiResult<T>(this Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Results.Ok(result),
            ResultStatus.Failure => Results.BadRequest(result),
            ResultStatus.Forbidden => Results.Forbid(),
            ResultStatus.Unauthorized => Results.Unauthorized(),
            ResultStatus.Invalid => Results.BadRequest(result),
            ResultStatus.NotFound => Results.NotFound(result),
            ResultStatus.Conflict => Results.Conflict(result),
            ResultStatus.Unsupported => Results.Json(result, statusCode: 501),
            ResultStatus.Unavailable => Results.Json(result, statusCode: 503),
            ResultStatus.ValidationError => Results.BadRequest(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="PagedResult{T}"/> instance to an appropriate <see cref="IResult"/> for Minimal APIs.
    /// </summary>
    /// <typeparam name="T">The type of the paged data contained in the result.</typeparam>
    /// <param name="result">The paged result to convert.</param>
    /// <returns>An <see cref="IResult"/> corresponding to the status of the <paramref name="result"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown when the result status is unknown or unsupported.</exception>
    public static IResult ToMinimalApiResult<T>(this PagedResult<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => Results.Ok(result),
            ResultStatus.Failure => Results.BadRequest(result),
            ResultStatus.Forbidden => Results.Forbid(),
            ResultStatus.Unauthorized => Results.Unauthorized(),
            ResultStatus.Invalid => Results.BadRequest(result),
            ResultStatus.NotFound => Results.NotFound(result),
            ResultStatus.Conflict => Results.Conflict(result),
            ResultStatus.Unsupported => Results.Json(result, statusCode: 501),
            ResultStatus.Unavailable => Results.Json(result, statusCode: 503),
            ResultStatus.ValidationError => Results.BadRequest(result),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result"/> object to a corresponding <see cref="ProblemDetails"/> object.
    /// </summary>
    /// <param name="result">The result to be converted.</param>
    /// <returns>
    /// A <see cref="ProblemDetails"/> object representing the details of the result.
    /// Returns <c>null</c> if the result is successful (i.e., <see cref="ResultStatus.Success"/>).
    /// </returns>
    /// <exception cref="NotSupportedException">Thrown when an unknown <see cref="ResultStatus"/> is encountered.</exception>
    public static ProblemDetails? ToProblemDetails(this Result result)
    {
        return result.Status switch
        {
            ResultStatus.Success => null,
            ResultStatus.Failure => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Failure})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Forbidden => new ProblemDetails
            {
                Status = 403,
                Title = $"An internal server error has occurred. ({ResultStatus.Forbidden})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unauthorized => new ProblemDetails
            {
                Status = 401,
                Title = $"An internal server error has occurred. ({ResultStatus.Unauthorized})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Invalid => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Invalid})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.ValidationError => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.ValidationError})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.NotFound => new ProblemDetails
            {
                Status = 404,
                Title = $"An internal server error has occurred. ({ResultStatus.NotFound})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Conflict => new ProblemDetails
            {
                Status = 409,
                Title = $"An internal server error has occurred. ({ResultStatus.Conflict})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unsupported => new ProblemDetails
            {
                Status = 501,
                Title = $"An internal server error has occurred. ({ResultStatus.Unsupported})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unavailable => new ProblemDetails
            {
                Status = 503,
                Title = $"An internal server error has occurred. ({ResultStatus.Unavailable})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> object to a corresponding <see cref="ProblemDetails"/> object.
    /// </summary>
    /// <typeparam name="T">The type of the result's value.</typeparam>
    /// <param name="result">The result to be converted.</param>
    /// <returns>
    /// A <see cref="ProblemDetails"/> object representing the details of the result.
    /// Returns <c>null</c> if the result is successful (i.e., <see cref="ResultStatus.Success"/>).
    /// </returns>
    /// <exception cref="NotSupportedException">Thrown when an unknown <see cref="ResultStatus"/> is encountered.</exception>
    public static ProblemDetails? ToProblemDetails<T>(this Result<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => null,
            ResultStatus.Failure => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Failure})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Forbidden => new ProblemDetails
            {
                Status = 403,
                Title = $"An internal server error has occurred. ({ResultStatus.Forbidden})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unauthorized => new ProblemDetails
            {
                Status = 401,
                Title = $"An internal server error has occurred. ({ResultStatus.Unauthorized})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Invalid => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Invalid})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.ValidationError => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.ValidationError})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.NotFound => new ProblemDetails
            {
                Status = 404,
                Title = $"An internal server error has occurred. ({ResultStatus.NotFound})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Conflict => new ProblemDetails
            {
                Status = 409,
                Title = $"An internal server error has occurred. ({ResultStatus.Conflict})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unsupported => new ProblemDetails
            {
                Status = 501,
                Title = $"An internal server error has occurred. ({ResultStatus.Unsupported})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unavailable => new ProblemDetails
            {
                Status = 503,
                Title = $"An internal server error has occurred. ({ResultStatus.Unavailable})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="PagedResult{T}"/> object to a corresponding <see cref="ProblemDetails"/> object.
    /// </summary>
    /// <typeparam name="T">The type of the result's value.</typeparam>
    /// <param name="result">The result to be converted.</param>
    /// <returns>
    /// A <see cref="ProblemDetails"/> object representing the details of the result.
    /// Returns <c>null</c> if the result is successful (i.e., <see cref="ResultStatus.Success"/>).
    /// </returns>
    /// <exception cref="NotSupportedException">Thrown when an unknown <see cref="ResultStatus"/> is encountered.</exception>
    public static ProblemDetails? ToProblemDetails<T>(this PagedResult<T> result)
    {
        return result.Status switch
        {
            ResultStatus.Success => null,
            ResultStatus.Failure => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Failure})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Forbidden => new ProblemDetails
            {
                Status = 403,
                Title = $"An internal server error has occurred. ({ResultStatus.Forbidden})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unauthorized => new ProblemDetails
            {
                Status = 401,
                Title = $"An internal server error has occurred. ({ResultStatus.Unauthorized})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Invalid => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.Invalid})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.ValidationError => new ProblemDetails
            {
                Status = 400,
                Title = $"An internal server error has occurred. ({ResultStatus.ValidationError})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.NotFound => new ProblemDetails
            {
                Status = 404,
                Title = $"An internal server error has occurred. ({ResultStatus.NotFound})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Conflict => new ProblemDetails
            {
                Status = 409,
                Title = $"An internal server error has occurred. ({ResultStatus.Conflict})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unsupported => new ProblemDetails
            {
                Status = 501,
                Title = $"An internal server error has occurred. ({ResultStatus.Unsupported})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            ResultStatus.Unavailable => new ProblemDetails
            {
                Status = 503,
                Title = $"An internal server error has occurred. ({ResultStatus.Unavailable})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }
}