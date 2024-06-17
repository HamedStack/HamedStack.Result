// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace HamedStack.TheResult;


/// <summary>
/// Provides extension methods for the Result class.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts a non-generic <see cref="Result"/> to a <see cref="Result{T}"/> with an optional value.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The non-generic result instance.</param>
    /// <param name="value">The optional value to include in the new result.</param>
    /// <returns>A new <see cref="Result{T}"/> instance with the same status and errors as the input result.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the result status is not recognized.</exception>
    public static Result<T> AsResult<T>(this Result result, T? value = default)
    {
        return result.Status switch
        {
            ResultStatus.Success => Result<T>.Success(value, result.SuccessMessage),
            ResultStatus.Failure => Result<T>.Failure(value, result.Errors),
            ResultStatus.Forbidden => Result<T>.Forbidden(value, result.Errors),
            ResultStatus.Unauthorized => Result<T>.Unauthorized(value, result.Errors),
            ResultStatus.Invalid => Result<T>.Invalid(value, result.Errors),
            ResultStatus.NotFound => Result<T>.NotFound(value, result.Errors),
            ResultStatus.Conflict => Result<T>.Conflict(value, result.Errors),
            ResultStatus.Unavailable => Result<T>.Unavailable(value, result.Errors),
            ResultStatus.Unsupported => Result<T>.Unsupported(value, result.Errors),
            ResultStatus.ValidationError => Result<T>.ValidationError(value, result.Errors),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    /// <summary>
    /// Gets the error messages from the result.
    /// </summary>
    /// <param name="result">The non-generic result instance.</param>
    /// <returns>An array of error messages.</returns>
    public static string[] GetErrorMessages(this Result result)
    {
        return result.Errors.Select(e => e.Message).ToArray();
    }
}