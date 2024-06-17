// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.TheResult;
/// <summary>
/// Represents the outcome of an operation with a specific return type, providing a standardized way to communicate success, failure, and related metadata.
/// </summary>
/// <typeparam name="T">The type of the value returned by the operation.</typeparam>
public class Result<T> : Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class with the specified value.
    /// </summary>
    /// <param name="value">The value of the operation result.</param>
    public Result(T? value)
    {
        Value = value;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Result{T}"/> class. Protected to prevent instantiation outside of factory methods.
    /// </summary>
    protected Result() { }
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
    /// Creates a conflict result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="Result{T}"/>.</returns>
    public static Result<T> Conflict(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Conflict)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Conflict };
    }

    public static Result<T> Conflict(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Conflict };
    }

    public static Result<T> Conflict(params string[] errorMessages)
    {
        return Conflict(default, errorMessages);
    }

    public static Result<T> Conflict(params Error[] errors)
    {
        return Conflict(default, errors);
    }

    /// <summary>
    /// Creates an failure result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the failure result.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="Result{T}"/>.</returns>
    public static Result<T> Failure(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Failure)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Failure };
    }

    public static Result<T> Failure(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Failure };
    }

    public static Result<T> Failure(params string[] errorMessages)
    {
        return Failure(default, errorMessages);
    }

    public static Result<T> Failure(params Error[] errors)
    {
        return Failure(default, errors);
    }

    /// <summary>
    /// Creates a forbidden result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result{T}"/>.</returns>
    public static Result<T> Forbidden(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Forbidden)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Forbidden };
    }

    public static Result<T> Forbidden(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Forbidden };
    }

    public static Result<T> Forbidden(params string[] errorMessages)
    {
        return Forbidden(default, errorMessages);
    }

    public static Result<T> Forbidden(params Error[] errors)
    {
        return Forbidden(default, errors);
    }

    /// <summary>
    /// Allows implicit conversion from <typeparamref name="T"/> to <see cref="Result{T}"/>, facilitating the creation of a result from a value directly.
    /// </summary>
    /// <param name="value">The value to wrap in a <see cref="Result{T}"/>.</param>
    /// <returns>A <see cref="Result{T}"/> wrapping the provided value.</returns>
    public static implicit operator Result<T>(T? value) => new(value);

    /// <summary>
    /// Allows implicit conversion from <see cref="Result{T}"/> to <typeparamref name="T"/>, enabling the value to be used directly.
    /// </summary>
    /// <param name="result">The result from which to extract the value.</param>
    /// <returns>The value of the result.</returns>
    public static implicit operator T?(Result<T> result) => result.Value;

    /// <summary>
    /// Creates an invalid result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="Result{T}"/>.</returns>
    public static Result<T> Invalid(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Invalid)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Invalid };
    }

    public static Result<T> Invalid(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Invalid };
    }

    public static Result<T> Invalid(params string[] errorMessages)
    {
        return Invalid(default, errorMessages);
    }

    public static Result<T> Invalid(params Error[] errors)
    {
        return Invalid(default, errors);
    }

    /// <summary>
    /// Creates a not found result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="Result{T}"/>.</returns>
    public static Result<T> NotFound(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.NotFound)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.NotFound };
    }

    public static Result<T> NotFound(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.NotFound };
    }

    public static Result<T> NotFound(params string[] errorMessages)
    {
        return NotFound(default, errorMessages);
    }

    public static Result<T> NotFound(params Error[] errors)
    {
        return NotFound(default, errors);
    }

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
    /// Creates an unauthorized result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result{T}"/>.</returns>
    public static Result<T> Unauthorized(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Unauthorized)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unauthorized };
    }
    public static Result<T> Unauthorized(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unauthorized };
    }
    public static Result<T> Unauthorized(params string[] errorMessages)
    {
        return Unauthorized(default, errorMessages);
    }

    public static Result<T> Unauthorized(params Error[] errors)
    {
        return Unauthorized(default, errors);
    }

    /// <summary>
    /// Creates an unavailable result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result{T}"/>.</returns>
    public static Result<T> Unavailable(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Unavailable)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }
    public static Result<T> Unavailable(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }
    public static Result<T> Unavailable(params string[] errorMessages)
    {
        return Unavailable(default, errorMessages);
    }

    public static Result<T> Unavailable(params Error[] errors)
    {
        return Unavailable(default, errors);
    }

    /// <summary>
    /// Creates an unsupported result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unsupported result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="Result{T}"/>.</returns>
    public static Result<T> Unsupported(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.Unsupported)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unsupported };
    }
    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating an unsupported operation, with the provided value and errors.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the result, which may represent a default or relevant value in the context of the unsupported operation.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the reasons why the operation is unsupported.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, the provided errors, and the <c>Status</c> set to <see cref="ResultStatus.Unavailable"/>.</returns>
    public static Result<T> Unsupported(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }

    public static Result<T> Unsupported(params string[] errorMessages)
    {
        return Unsupported(default, errorMessages);
    }

    public static Result<T> Unsupported(params Error[] errors)
    {
        return Unsupported(default, errors);
    }

    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating a validation failure, with custom error messages and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errorMessages">An array of error messages that describe the validation failures.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, errors generated from the provided messages with a <see cref="ErrorType.ValidationError"/> type, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result<T> ValidationError(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e, ErrorType.ValidationError)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating a validation failure, with specified <see cref="Error"/> objects and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the validation failures.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result<T> ValidationError(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.ValidationError };
    }
    public static Result<T> ValidationError(params string[] errorMessages)
    {
        return ValidationError(default, errorMessages);
    }

    public static Result<T> ValidationError(params Error[] errors)
    {
        return ValidationError(default, errors);
    }
}
