// ReSharper disable UnusedMember.Global

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            ResultStatus.Success => new ObjectResult(result) { StatusCode = 200 },
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            ResultStatus.CriticalError => new ObjectResult(result) { StatusCode = 500 },
            ResultStatus.NoContent => new NoContentResult(),
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
            ResultStatus.Success => new ObjectResult(result) { StatusCode = 200 },
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            ResultStatus.CriticalError => new ObjectResult(result) { StatusCode = 500 },
            ResultStatus.NoContent => new NoContentResult(),
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
            ResultStatus.Success => new ObjectResult(result) { StatusCode = 200 },
            ResultStatus.Failure => new BadRequestObjectResult(result),
            ResultStatus.Forbidden => new ForbidResult(),
            ResultStatus.Unauthorized => new UnauthorizedObjectResult(result),
            ResultStatus.Invalid => new BadRequestObjectResult(result),
            ResultStatus.NotFound => new NotFoundObjectResult(result),
            ResultStatus.Conflict => new ConflictObjectResult(result),
            ResultStatus.Unsupported => new ObjectResult(result) { StatusCode = 501 },
            ResultStatus.Unavailable => new ObjectResult(result) { StatusCode = 503 },
            ResultStatus.ValidationError => new BadRequestObjectResult(result),
            ResultStatus.CriticalError => new ObjectResult(result) { StatusCode = 500 },
            ResultStatus.NoContent => new NoContentResult(),
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result"/> instance to an appropriate <see cref="IResult"/> for Minimal APIs.
    /// </summary>
    /// <param name="result">The result to convert.</param>
    /// <returns>An <see cref="IResult"/> corresponding to the status of the <paramref name="result"/>.</returns>
    /// <exception cref="NotSupportedException">Thrown when the result status is unknown or unsupported.</exception>
    public static IResult ToMinimalApiResult(this Result result)
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
            ResultStatus.CriticalError => Results.Json(result, statusCode: 500),
            ResultStatus.NoContent => Results.NoContent(),
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
            ResultStatus.CriticalError => Results.Json(result, statusCode: 500),
            ResultStatus.NoContent => Results.NoContent(),
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
            ResultStatus.CriticalError => Results.Json(result, statusCode: 500),
            ResultStatus.NoContent => Results.NoContent(),
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
            ResultStatus.CriticalError => new ProblemDetails
            {
                Status = 500,
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
            ResultStatus.CriticalError => new ProblemDetails
            {
                Status = 500,
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
            ResultStatus.CriticalError => new ProblemDetails
            {
                Status = 500,
                Title = $"An internal server error has occurred. ({ResultStatus.Unavailable})",
                Detail = result.GetErrorMessages().Aggregate((a, b) => a + ", " + b),
            },
            _ => throw new NotSupportedException($"Unknown result status: {result.Status}"),
        };
    }

    /// <summary>
    /// Converts a <see cref="Result"/> to an <see cref="IActionResult"/> with the specified HTTP status code.
    /// </summary>
    /// <param name="result">The result to transform.</param>
    /// <param name="statusCode">The HTTP status code to return.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result.</returns>
    public static IActionResult ToActionResult(this Result result, HttpStatusCode statusCode)
    {
        return new ObjectResult(result)
        {
            StatusCode = (int)statusCode
        };
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> to an <see cref="IActionResult"/> with the specified HTTP status code.
    /// </summary>
    /// <typeparam name="T">The type of the value in the result.</typeparam>
    /// <param name="result">The result to transform.</param>
    /// <param name="statusCode">The HTTP status code to return.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result.</returns>
    public static IActionResult ToActionResult<T>(this Result<T> result, HttpStatusCode statusCode)
    {
        return new ObjectResult(result)
        {
            StatusCode = (int)statusCode
        };
    }

    /// <summary>
    /// Converts a <see cref="PagedResult{T}"/> to an <see cref="IActionResult"/> with the specified HTTP status code.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result to transform.</param>
    /// <param name="statusCode">The HTTP status code to return.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result.</returns>
    public static IActionResult ToActionResult<T>(this PagedResult<T> result, HttpStatusCode statusCode)
    {
        return new ObjectResult(result)
        {
            StatusCode = (int)statusCode
        };
    }

    /// <summary>
    /// Converts a successful Result with a value to a Created (201) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IActionResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToCreatedResult<T>(this Result<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }

        return new CreatedResult(location, result.Value);
    }

    /// <summary>
    /// Converts a successful Result to a Created (201) response for MVC controllers without a body.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IActionResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToCreatedResult(this Result result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }

        return new CreatedResult(location, string.Empty);
    }

    /// <summary>
    /// Converts a successful PagedResult to a Created (201) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="pagedResult">The paged result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IActionResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToCreatedResult<T>(this PagedResult<T> pagedResult, string location)
    {
        if (pagedResult.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }

        return new CreatedResult(location, pagedResult.Value);
    }
    /// <summary>
    /// Converts a successful Result with a value to a Created (201) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToCreatedMinimalApiResult<T>(this Result<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }

        return Results.Created(location, result.Value);
    }

    /// <summary>
    /// Converts a successful Result to a Created (201) Minimal API result without a body.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToCreatedMinimalApiResult(this Result result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }

        return Results.Created(location, string.Empty);
    }

    /// <summary>
    /// Converts a successful PagedResult to a Created (201) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="pagedResult">The paged result object.</param>
    /// <param name="location">The location URI for the created resource.</param>
    /// <returns>An IResult representing a Created response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToCreatedMinimalApiResult<T>(this PagedResult<T> pagedResult, string location)
    {
        if (pagedResult.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }

        return Results.Created(location, pagedResult.Value);
    }

    /// <summary>
    /// Converts a successful Result to an Accepted (202) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IActionResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToAcceptedResult(this Result result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new AcceptedResult(location, result);
    }

    /// <summary>
    /// Converts a successful Result to an Accepted (202) response with a value for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IActionResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToAcceptedResult<T>(this Result<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new AcceptedResult(location, result.Value);
    }

    /// <summary>
    /// Converts a successful PagedResult to an Accepted (202) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IActionResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToAcceptedResult<T>(this PagedResult<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return new AcceptedResult(location, result.Value);
    }


    /// <summary>
    /// Converts a successful Result to an Accepted (202) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToAcceptedMinimalApiResult(this Result result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.Accepted(location, result);
    }
    /// <summary>
    /// Converts a successful Result with a value to an Accepted (202) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToAcceptedMinimalApiResult<T>(this Result<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.Accepted(location, result.Value);
    }
    /// <summary>
    /// Converts a successful PagedResult to an Accepted (202) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <param name="location">The URI of the accepted resource.</param>
    /// <returns>An IResult representing an Accepted response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToAcceptedMinimalApiResult<T>(this PagedResult<T> result, string location)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return Results.Accepted(location, result.Value);
    }

    /// <summary>
    /// Converts a failed Result to a Bad Request (400) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IActionResult ToBadRequestResult(this Result result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("Result must have a status of Failure or ValidationError.");
        }
        return new BadRequestObjectResult(result);
    }

    /// <summary>
    /// Converts a failed Result with a value to a Bad Request (400) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IActionResult ToBadRequestResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("Result must have a status of Failure or ValidationError.");
        }
        return new BadRequestObjectResult(result);
    }

    /// <summary>
    /// Converts a failed PagedResult to a Bad Request (400) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IActionResult ToBadRequestResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("PagedResult must have a status of Failure or ValidationError.");
        }
        return new BadRequestObjectResult(result);
    }

    /// <summary>
    /// Converts a failed Result to a Bad Request (400) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IResult ToBadRequestMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("Result must have a status of Failure or ValidationError.");
        }
        return Results.BadRequest(result);
    }
    /// <summary>
    /// Converts a failed Result with a value to a Bad Request (400) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IResult ToBadRequestMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("Result must have a status of Failure or ValidationError.");
        }
        return Results.BadRequest(result);
    }
    /// <summary>
    /// Converts a failed PagedResult to a Bad Request (400) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a Bad Request response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Failure or ValidationError.</exception>
    public static IResult ToBadRequestMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Failure && result.Status != ResultStatus.ValidationError)
        {
            throw new ArgumentException("PagedResult must have a status of Failure or ValidationError.");
        }
        return Results.BadRequest(result);
    }
    /// <summary>
    /// Converts an unauthorized Result to an Unauthorized (401) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IActionResult ToUnauthorizedResult(this Result result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("Result must have a status of Unauthorized.");
        }
        return new UnauthorizedObjectResult(result);
    }
    /// <summary>
    /// Converts an unauthorized Result with a value to an Unauthorized (401) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IActionResult ToUnauthorizedResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("Result must have a status of Unauthorized.");
        }
        return new UnauthorizedObjectResult(result);
    }
    /// <summary>
    /// Converts an unauthorized PagedResult to an Unauthorized (401) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IActionResult ToUnauthorizedResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("PagedResult must have a status of Unauthorized.");
        }
        return new UnauthorizedObjectResult(result);
    }
    /// <summary>
    /// Converts an unauthorized Result to an Unauthorized (401) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IResult ToUnauthorizedMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("Result must have a status of Unauthorized.");
        }
        return Results.Unauthorized();
    }
    /// <summary>
    /// Converts an unauthorized Result with a value to an Unauthorized (401) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IResult ToUnauthorizedMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("Result must have a status of Unauthorized.");
        }
        return Results.Unauthorized();
    }
    /// <summary>
    /// Converts an unauthorized PagedResult to an Unauthorized (401) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing an Unauthorized response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unauthorized.</exception>
    public static IResult ToUnauthorizedMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unauthorized)
        {
            throw new ArgumentException("PagedResult must have a status of Unauthorized.");
        }
        return Results.Unauthorized();
    }
    /// <summary>
    /// Converts a forbidden Result to a Forbidden (403) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>
    public static IActionResult ToForbiddenResult(this Result result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("Result must have a status of Forbidden.");
        }
        return new ForbidResult();
    }
    /// <summary>
    /// Converts a forbidden Result with a value to a Forbidden (403) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>
    public static IActionResult ToForbiddenResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("Result must have a status of Forbidden.");
        }
        return new ForbidResult();
    }
    /// <summary>
    /// Converts a forbidden PagedResult to a Forbidden (403) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>
    public static IActionResult ToForbiddenResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("PagedResult must have a status of Forbidden.");
        }
        return new ForbidResult();
    }

    /// <summary>
    /// Converts a forbidden Result to a Forbidden (403) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>
    public static IResult ToForbiddenMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("Result must have a status of Forbidden.");
        }
        return Results.Forbid();
    }
    /// <summary>
    /// Converts a forbidden Result with a value to a Forbidden (403) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>
    public static IResult ToForbiddenMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("Result must have a status of Forbidden.");
        }
        return Results.Forbid();
    }
    /// <summary>
    /// Converts a forbidden PagedResult to a Forbidden (403) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a Forbidden response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Forbidden.</exception>

    public static IResult ToForbiddenMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Forbidden)
        {
            throw new ArgumentException("PagedResult must have a status of Forbidden.");
        }
        return Results.Forbid();
    }
    /// <summary>
    /// Converts a not found Result to a Not Found (404) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>

    public static IActionResult ToNotFoundResult(this Result result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("Result must have a status of NotFound.");
        }
        return new NotFoundObjectResult(result);
    }
    /// <summary>
    /// Converts a not found Result with a value to a Not Found (404) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>

    public static IActionResult ToNotFoundResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("Result must have a status of NotFound.");
        }
        return new NotFoundObjectResult(result);
    }
    /// <summary>
    /// Converts a not found PagedResult to a Not Found (404) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>

    public static IActionResult ToNotFoundResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("PagedResult must have a status of NotFound.");
        }
        return new NotFoundObjectResult(result);
    }
    /// <summary>
    /// Converts a not found Result to a Not Found (404) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>
    public static IResult ToNotFoundMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("Result must have a status of NotFound.");
        }
        return Results.NotFound(result);
    }

    /// <summary>
    /// Converts a not found Result with a value to a Not Found (404) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>
    public static IResult ToNotFoundMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("Result must have a status of NotFound.");
        }
        return Results.NotFound(result);
    }

    /// <summary>
    /// Converts a not found PagedResult to a Not Found (404) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a Not Found response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not NotFound.</exception>
    public static IResult ToNotFoundMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.NotFound)
        {
            throw new ArgumentException("PagedResult must have a status of NotFound.");
        }
        return Results.NotFound(result);
    }

    /// <summary>
    /// Converts a conflicting Result to a Conflict (409) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IActionResult ToConflictResult(this Result result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("Result must have a status of Conflict.");
        }
        return new ConflictObjectResult(result);
    }

    /// <summary>
    /// Converts a conflicting Result with a value to a Conflict (409) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IActionResult ToConflictResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("Result must have a status of Conflict.");
        }
        return new ConflictObjectResult(result);
    }

    /// <summary>
    /// Converts a conflicting PagedResult to a Conflict (409) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IActionResult ToConflictResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("PagedResult must have a status of Conflict.");
        }
        return new ConflictObjectResult(result);
    }

    /// <summary>
    /// Converts a conflicting Result to a Conflict (409) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IResult ToConflictMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("Result must have a status of Conflict.");
        }
        return Results.Conflict(result);
    }

    /// <summary>
    /// Converts a conflicting Result with a value to a Conflict (409) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IResult ToConflictMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("Result must have a status of Conflict.");
        }
        return Results.Conflict(result);
    }

    /// <summary>
    /// Converts a conflicting PagedResult to a Conflict (409) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a Conflict response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Conflict.</exception>
    public static IResult ToConflictMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Conflict)
        {
            throw new ArgumentException("PagedResult must have a status of Conflict.");
        }
        return Results.Conflict(result);
    }

    /// <summary>
    /// Converts a successful Result to an OK (200) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToOkResult(this Result result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new ObjectResult(result) { StatusCode = 200 };
    }

    /// <summary>
    /// Converts a successful Result with a value to an OK (200) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToOkResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new ObjectResult(result) { StatusCode = 200 };
    }

    /// <summary>
    /// Converts a successful PagedResult to an OK (200) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToOkResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return new ObjectResult(result) { StatusCode = 200 };
    }
    /// <summary>
    /// Converts a successful Result to an OK (200) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToOkMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.Ok(result);
    }
    /// <summary>
    /// Converts a successful Result with a value to an OK (200) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToOkMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.Ok(result);
    }
    /// <summary>
    /// Converts a successful PagedResult to an OK (200) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing an OK response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToOkMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return Results.Ok(result);
    }
    /// <summary>
    /// Converts an unsupported Result to a Not Implemented (501) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IActionResult ToUnsupportedResult(this Result result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("Result must have a status of Unsupported.");
        }
        return new ObjectResult(result) { StatusCode = 501 };
    }
    /// <summary>
    /// Converts an unsupported Result with a value to a Not Implemented (501) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IActionResult ToUnsupportedResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("Result must have a status of Unsupported.");
        }
        return new ObjectResult(result) { StatusCode = 501 };
    }
    /// <summary>
    /// Converts an unsupported PagedResult to a Not Implemented (501) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IActionResult ToUnsupportedResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("PagedResult must have a status of Unsupported.");
        }
        return new ObjectResult(result) { StatusCode = 501 };
    }
    /// <summary>
    /// Converts an unsupported Result to a Not Implemented (501) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IResult ToUnsupportedMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("Result must have a status of Unsupported.");
        }
        return Results.Json(result, statusCode: 501);
    }
    /// <summary>
    /// Converts an unsupported Result with a value to a Not Implemented (501) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IResult ToUnsupportedMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("Result must have a status of Unsupported.");
        }
        return Results.Json(result, statusCode: 501);
    }
    /// <summary>
    /// Converts an unsupported PagedResult to a Not Implemented (501) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Not Implemented response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unsupported.</exception>
    public static IResult ToUnsupportedMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unsupported)
        {
            throw new ArgumentException("PagedResult must have a status of Unsupported.");
        }
        return Results.Json(result, statusCode: 501);
    }

    /// <summary>
    /// Converts an unavailable Result to a Service Unavailable (503) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IActionResult ToUnavailableResult(this Result result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("Result must have a status of Unavailable.");
        }
        return new ObjectResult(result) { StatusCode = 503 };
    }
    /// <summary>
    /// Converts an unavailable Result with a value to a Service Unavailable (503) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IActionResult ToUnavailableResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("Result must have a status of Unavailable.");
        }
        return new ObjectResult(result) { StatusCode = 503 };
    }
    /// <summary>
    /// Converts an unavailable PagedResult to a Service Unavailable (503) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IActionResult ToUnavailableResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("PagedResult must have a status of Unavailable.");
        }
        return new ObjectResult(result) { StatusCode = 503 };
    }
    /// <summary>
    /// Converts an unavailable Result to a Service Unavailable (503) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IResult ToUnavailableMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("Result must have a status of Unavailable.");
        }
        return Results.Json(result, statusCode: 503);
    }
    /// <summary>
    /// Converts an unavailable Result with a value to a Service Unavailable (503) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IResult ToUnavailableMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("Result must have a status of Unavailable.");
        }
        return Results.Json(result, statusCode: 503);
    }
    /// <summary>
    /// Converts an unavailable PagedResult to a Service Unavailable (503) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a Service Unavailable response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Unavailable.</exception>
    public static IResult ToUnavailableMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Unavailable)
        {
            throw new ArgumentException("PagedResult must have a status of Unavailable.");
        }
        return Results.Json(result, statusCode: 503);
    }
    /// <summary>
    /// Converts a successful Result to a No Content (204) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToNoContentResult(this Result result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new NoContentResult();
    }
    /// <summary>
    /// Converts a successful Result with a value to a No Content (204) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToNoContentResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return new NoContentResult();
    }
    /// <summary>
    /// Converts a successful PagedResult to a No Content (204) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IActionResult ToNoContentResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return new NoContentResult();
    }
    /// <summary>
    /// Converts a successful Result to a No Content (204) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToNoContentMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.NoContent();
    }
    /// <summary>
    /// Converts a successful Result with a value to a No Content (204) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToNoContentMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("Result must have a status of success.");
        }
        return Results.NoContent();
    }
    /// <summary>
    /// Converts a successful PagedResult to a No Content (204) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing a No Content response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not Success.</exception>
    public static IResult ToNoContentMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.Success)
        {
            throw new ArgumentException("PagedResult must have a status of success.");
        }
        return Results.NoContent();
    }
    /// <summary>
    /// Converts a critical error Result to an Internal Server Error (500) response for MVC controllers.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IActionResult ToCriticalErrorResult(this Result result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("Result must have a status of CriticalError.");
        }
        return new ObjectResult(result) { StatusCode = 500 };
    }
    /// <summary>
    /// Converts a critical error Result with a value to an Internal Server Error (500) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IActionResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IActionResult ToCriticalErrorResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("Result must have a status of CriticalError.");
        }
        return new ObjectResult(result) { StatusCode = 500 };
    }
    /// <summary>
    /// Converts a critical error PagedResult to an Internal Server Error (500) response for MVC controllers.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IActionResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IActionResult ToCriticalErrorResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("PagedResult must have a status of CriticalError.");
        }
        return new ObjectResult(result) { StatusCode = 500 };
    }
    /// <summary>
    /// Converts a critical error Result to an Internal Server Error (500) Minimal API result.
    /// </summary>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IResult ToCriticalErrorMinimalApiResult(this Result result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("Result must have a status of CriticalError.");
        }
        return Results.Json(result, statusCode: 500);
    }
    /// <summary>
    /// Converts a critical error Result with a value to an Internal Server Error (500) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the result value.</typeparam>
    /// <param name="result">The result object.</param>
    /// <returns>An IResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IResult ToCriticalErrorMinimalApiResult<T>(this Result<T> result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("Result must have a status of CriticalError.");
        }
        return Results.Json(result, statusCode: 500);
    }
    /// <summary>
    /// Converts a critical error PagedResult to an Internal Server Error (500) Minimal API result.
    /// </summary>
    /// <typeparam name="T">The type of the paged result value.</typeparam>
    /// <param name="result">The paged result object.</param>
    /// <returns>An IResult representing an Internal Server Error response.</returns>
    /// <exception cref="ArgumentException">Thrown if the result status is not CriticalError.</exception>
    public static IResult ToCriticalErrorMinimalApiResult<T>(this PagedResult<T> result)
    {
        if (result.Status != ResultStatus.CriticalError)
        {
            throw new ArgumentException("PagedResult must have a status of CriticalError.");
        }
        return Results.Json(result, statusCode: 500);
    }
}