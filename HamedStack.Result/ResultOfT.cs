// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.Result;
/// <summary>
/// Represents the outcome of an operation with a specific return type, providing a standardized way to communicate success, failure, and related metadata.
/// </summary>
/// <typeparam name="T">The type of the value returned by the operation.</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class. Protected to prevent instantiation outside of factory methods.
    /// </summary>
    protected Result() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value of the operation result.</param>
    public Result(T? value)
    {
        Value = value;
    }

    /// <summary>
    /// Gets or sets the value of the operation result.
    /// </summary>
    /// <value>The value of the type <typeparamref name="T"/>.</value>
    public T? Value { get; set; }

    /// <summary>
    /// Gets the type of the value.
    /// </summary>
    /// <value>The type of the value.</value>
    [JsonIgnore]
    public Type ValueType => typeof(T);

    /// <summary>
    /// Creates a success result with the specified value.
    /// </summary>
    /// <param name="value">The value to return with the result.</param>
    /// <returns>A success <see cref="Result{T}"/> with the specified value.</returns>
    public static Result<T> Success(T? value)
    {
        return new Result<T> { IsSuccess = true, Value = value, Status = ResultStatus.Success };
    }

    /// <summary>
    /// Creates a success result with the specified value and success message.
    /// </summary>
    /// <param name="value">The value to return with the result.</param>
    /// <param name="successMessage">The success message.</param>
    /// <returns>A success <see cref="Result{T}"/> with the specified value and success message.</returns>
    public static Result<T> Success(T? value, string successMessage)
    {
        return new Result<T> { IsSuccess = true, Value = value, SuccessMessage = successMessage, Status = ResultStatus.Success };
    }

    /// <summary>
    /// Creates an error result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the error result.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="Result{T}"/>.</returns>
    public static Result<T> Error(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Error };
    }

    /// <summary>
    /// Creates a forbidden result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result{T}"/>.</returns>
    public static Result<T> Forbidden(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates an unauthorized result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result{T}"/>.</returns>
    public static Result<T> Unauthorized(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an invalid result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="Result{T}"/>.</returns>
    public static Result<T> Invalid(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a not found result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="Result{T}"/>.</returns>
    public static Result<T> NotFound(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a conflict result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="Result{T}"/>.</returns>
    public static Result<T> Conflict(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates an unavailable result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result{T}"/>.</returns>
    public static Result<T> Unavailable(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unsupported result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unsupported result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="Result{T}"/>.</returns>
    public static Result<T> Unsupported(T? value, params string[] errorMessages)
    {
        return new Result<T> { IsSuccess = false, Value = value, ErrorMessages = errorMessages, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Allows implicit conversion from <see cref="Result{T}"/> to <typeparamref name="T"/>, enabling the value to be used directly.
    /// </summary>
    /// <param name="result">The result from which to extract the value.</param>
    /// <returns>The value of the result.</returns>
    public static implicit operator T?(Result<T> result) => result.Value;

    /// <summary>
    /// Allows implicit conversion from <typeparamref name="T"/> to <see cref="Result{T}"/>, facilitating the creation of a result from a value directly.
    /// </summary>
    /// <param name="value">The value to wrap in a <see cref="Result{T}"/>.</param>
    /// <returns>A <see cref="Result{T}"/> wrapping the provided value.</returns>
    public static implicit operator Result<T>(T value) => new(value);
}
