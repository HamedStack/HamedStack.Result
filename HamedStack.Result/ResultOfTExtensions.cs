// ReSharper disable UnusedMember.Global
// ReSharper disable IdentifierTypo

namespace HamedStack.TheResult;

/// <summary>
/// Provides extension methods for the Result&lt;T&gt;.
/// </summary>
public static class ResultOfTExtensions
{
    /// <summary>
    /// Binds a function to the result if it is successful, propagating errors otherwise.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="bind">The function to bind.</param>
    /// <returns>A new result of type <see cref="Result{TOut}"/>.</returns>
    public static Result<TOut> Bind<TIn, TOut>(this Result<TIn> result, Func<TIn?, Result<TOut>> bind)
    {
        return result.IsSuccess
            ? bind(result.Value)
            : Result<TOut>.Failure(default, result.Errors);
    }

    /// <summary>
    /// Gets the error messages from the result.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result instance.</param>
    /// <returns>An array of error messages.</returns>
    public static string[] GetErrorMessages<T>(this Result<T> result)
    {
        return result.Errors.Select(e => e.Message).ToArray();
    }

    /// <summary>
    /// Maps the value of the result to a new result, preserving the original result status.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="mapper">The function to apply to the value if the result is successful.</param>
    /// <returns>A new result of type <see cref="Result{TOut}"/> with the mapped value.</returns>
    public static Result<TOut> Map<TIn, TOut>(this Result<TIn> result, Func<TIn?, TOut> mapper)
    {
        return result.IsSuccess
            ? Result<TOut>.Success(mapper(result.Value))
            : Result<TOut>.Failure(default, result.Errors);
    }

    /// <summary>
    /// Matches the result with success and failure functions.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="onSuccess">The function to execute if the result is successful.</param>
    /// <param name="onFailure">The function to execute if the result is a failure.</param>
    /// <returns>The output value of type <see cref="TOut"/>.</returns>
    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn?, TOut> onSuccess, Func<Error[], TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);
    }

    /// <summary>
    /// Matches the result with success and failure functions, providing error messages to the failure function.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="onSuccess">The function to execute if the result is successful.</param>
    /// <param name="onFailure">The function to execute if the result is a failure.</param>
    /// <returns>The output value of type <see cref="TOut"/>.</returns>
    public static TOut Match<TIn, TOut>(this Result<TIn> result, Func<TIn?, TOut> onSuccess, Func<string[], TOut> onFailure)
    {
        return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors.Select(err => err.Message).ToArray());
    }

    /// <summary>
    /// Executes an action if the result is successful.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="action">The action to execute.</param>
    /// <returns>The original result.</returns>
    public static Result<TIn> Tap<TIn>(this Result<TIn> result, Action<TIn> action)
    {
        if (result.IsSuccess) action(result.Value!);
        return result;
    }

    /// <summary>
    /// Executes a specified action if the result indicates a failure and returns the original result.
    /// </summary>
    /// <typeparam name="TIn">The type of the value stored in the result.</typeparam>
    /// <param name="result">The result object to be checked for success or failure.</param>
    /// <param name="actionOnFailure">The action to execute if the result indicates a failure.</param>
    /// <returns>The original result object.</returns>
    public static Result<TIn> TapError<TIn>(this Result<TIn> result, Action actionOnFailure)
    {
        if (!result.IsSuccess) actionOnFailure();
        return result;
    }

    /// <summary>
    /// Tries to apply a function to the result, catching any exceptions and converting them to a failure result.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="func">The function to apply.</param>
    /// <param name="error">The error to use if an exception is thrown.</param>
    /// <returns>A new result of type <see cref="Result{TOut}"/>.</returns>
    public static Result<TOut> TryCatch<TIn, TOut>(this Result<TIn> result, Func<TIn?, Result<TOut>> func, Error error)
    {
        try
        {
            return result.IsSuccess
                ? Result<TOut>.Success(func(result.Value))
                : Result<TOut>.Failure(default, result.Errors);
        }
        catch
        {
            return Result<TOut>.Failure(default, error);
        }
    }

    /// <summary>
    /// Tries to apply a function to the result, catching any exceptions and converting them to a failure result with the specified error type, message, and optional error code.
    /// </summary>
    /// <typeparam name="TIn">The type of the input value.</typeparam>
    /// <typeparam name="TOut">The type of the output value.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="func">The function to apply to the input result.</param>
    /// <param name="errorType">The error type to use if an exception is thrown.</param>
    /// <param name="errorMessage">The error message to use if an exception is thrown.</param>
    /// <param name="errorCode">The optional error code to use if an exception is thrown.</param>
    /// <returns>A new result of type <see cref="Result{TOut}"/>.</returns>
    public static Result<TOut> TryCatch<TIn, TOut>(this Result<TIn> result, Func<TIn?, Result<TOut>> func, string errorMessage, string? errorCode = null)
    {
        return result.TryCatch(func, string.IsNullOrWhiteSpace(errorCode) 
            ? new Error(errorMessage) 
            : new Error(errorMessage, errorCode));
    }
    
    /// <summary>
    /// Unwraps the result value or returns a default value if the result is a failure.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The input result.</param>
    /// <param name="defaultValue">The default value to return if the result is a failure.</param>
    /// <returns>The result value if successful; otherwise, the default value.</returns>
    public static T? UnwrapOr<T>(this Result<T> result, T? defaultValue)
    {
        return result.IsSuccess ? result.Value : defaultValue;
    }
}
