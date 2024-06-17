// ReSharper disable IdentifierTypo
// ReSharper disable UnusedMember.Global

namespace HamedStack.TheResult;

/// <summary>
/// Provides extension methods for the PagedResult class.
/// </summary>
public static class PagedResultExtensions
{
    /// <summary>
    /// Gets the error messages from the paged result.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the paged result.</typeparam>
    /// <param name="result">The paged result instance.</param>
    /// <returns>An array of error messages.</returns>
    public static string[] GetErrorMessages<T>(this PagedResult<T> result)
    {
        return result.Errors.Select(e => e.Message).ToArray();
    }

    /// <summary>
    /// Converts a non-generic <see cref="Result"/> to a <see cref="PagedResult{T}"/> with an optional value and paging information.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The non-generic result instance.</param>
    /// <param name="pagedInfo">The optional paging information to include in the new paged result.</param>
    /// <param name="value">The optional value to include in the new paged result.</param>
    /// <returns>A new <see cref="PagedResult{T}"/> instance with the same status and errors as the input result.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the result status is not recognized.</exception>
    public static PagedResult<T> AsPagedResult<T>(this Result result, PagedInfo? pagedInfo = null, T? value = default)
    {
        return result.Status switch
        {
            ResultStatus.Success when pagedInfo != null => PagedResult<T>.Success(value, pagedInfo, result.SuccessMessage),
            ResultStatus.Failure => PagedResult<T>.Failure(value, result.Errors),
            ResultStatus.Forbidden => PagedResult<T>.Forbidden(value, result.Errors),
            ResultStatus.Unauthorized => PagedResult<T>.Unauthorized(value, result.Errors),
            ResultStatus.Invalid => PagedResult<T>.Invalid(value, result.Errors),
            ResultStatus.NotFound => PagedResult<T>.NotFound(value, result.Errors),
            ResultStatus.Conflict => PagedResult<T>.Conflict(value, result.Errors),
            ResultStatus.Unavailable => PagedResult<T>.Unavailable(value, result.Errors),
            ResultStatus.Unsupported => PagedResult<T>.Unsupported(value, result.Errors),
            ResultStatus.ValidationError => PagedResult<T>.ValidationError(value, result.Errors),
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}
