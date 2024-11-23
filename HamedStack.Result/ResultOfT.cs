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
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a conflict result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="errors">The error objects indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="Result{T}"/>.</returns>
    public static Result<T> Conflict(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a conflict result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="exception">The exception indicating the reason for the conflict.</param>
    /// <returns>A conflict <see cref="Result{T}"/>.</returns>
    public static Result<T> Conflict(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a result indicating a conflict, with custom error messages and a default value.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the conflict.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, errors generated from the provided messages with a <see cref="ErrorType.Conflict"/> type, and the <c>Status</c> set to <see cref="ResultStatus.Conflict"/>.</returns>
    public new static Result<T> Conflict(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a result indicating a conflict, with the specified <see cref="Error"/> objects and a default value.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the conflict.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Conflict"/>.</returns>
    public new static Result<T> Conflict(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a result indicating a conflict, with the provided exception message and a default value.
    /// </summary>
    /// <param name="exception">The exception indicating the reason for the conflict.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, a default value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.Conflict"/>.</returns>
    public new static Result<T> Conflict(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a failure result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the failure result.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="Result{T}"/>.</returns>
    public static Result<T> Failure(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a failure result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the failure result.</param>
    /// <param name="errors">The error objects indicating why the operation failed.</param>
    /// <returns>A failure <see cref="Result{T}"/>.</returns>
    public static Result<T> Failure(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a failure result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the failure result.</param>
    /// <param name="exception">The exception indicating the reason for the failure.</param>
    /// <returns>A failure <see cref="Result{T}"/>.</returns>
    public static Result<T> Failure(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a result indicating a general failure, with custom error messages and a default value.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the failure.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, errors generated from the provided messages, and the <c>Status</c> set to <see cref="ResultStatus.Failure"/>.</returns>
    public new static Result<T> Failure(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a result indicating a general failure, with the specified <see cref="Error"/> objects and a default value.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the failure.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Failure"/>.</returns>
    public new static Result<T> Failure(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a result indicating a general failure, with the provided exception message and a default value.
    /// </summary>
    /// <param name="exception">The exception indicating the reason for the failure.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, a default value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.Failure"/>.</returns>
    public new static Result<T> Failure(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a forbidden result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result{T}"/>.</returns>
    public static Result<T> Forbidden(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a forbidden result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errors">The error objects indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result{T}"/>.</returns>
    public static Result<T> Forbidden(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a forbidden result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="exception">The exception indicating the reason for the forbidden operation.</param>
    /// <returns>A forbidden <see cref="Result{T}"/>.</returns>
    public static Result<T> Forbidden(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a result indicating a forbidden action, with custom error messages and a default value.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the forbidden action.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, errors generated from the provided messages, and the <c>Status</c> set to <see cref="ResultStatus.Forbidden"/>.</returns>
    public new static Result<T> Forbidden(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a result indicating a forbidden action, with the specified <see cref="Error"/> objects and a default value.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the forbidden action.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Forbidden"/>.</returns>
    public new static Result<T> Forbidden(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a result indicating a forbidden action, with the provided exception message and a default value.
    /// </summary>
    /// <param name="exception">The exception indicating the reason for the forbidden action.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, a default value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.Forbidden"/>.</returns>
    public new static Result<T> Forbidden(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Forbidden };
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
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates an invalid result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="errors">The error objects indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="Result{T}"/>.</returns>
    public static Result<T> Invalid(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates an invalid result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="exception">The exception indicating the reason for the invalid operation.</param>
    /// <returns>An invalid <see cref="Result{T}"/>.</returns>
    public static Result<T> Invalid(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a result indicating an invalid action, with custom error messages and a default value.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the invalid action.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, errors generated from the provided messages, and the <c>Status</c> set to <see cref="ResultStatus.Invalid"/>.</returns>
    public new static Result<T> Invalid(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a result indicating an invalid action, with the specified <see cref="Error"/> objects and a default value.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the invalid action.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Invalid"/>.</returns>
    public new static Result<T> Invalid(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a result indicating an invalid action, with the provided exception message and a default value.
    /// </summary>
    /// <param name="exception">The exception indicating the reason for the invalid action.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, a default value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.Invalid"/>.</returns>
    public new static Result<T> Invalid(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a not found result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="Result{T}"/>.</returns>
    public static Result<T> NotFound(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a not found result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errors">The error objects indicating why the operation failed to find the resource.</param>
    /// <returns>A not found <see cref="Result{T}"/>.</returns>
    public static Result<T> NotFound(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a not found result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="exception">The exception indicating the reason for the not found operation.</param>
    /// <returns>A not found <see cref="Result{T}"/>.</returns>
    public static Result<T> NotFound(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a result indicating that the requested resource was not found, with custom error messages and a default value.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the reason the resource was not found.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, errors generated from the provided messages, and the <c>Status</c> set to <see cref="ResultStatus.NotFound"/>.</returns>
    public new static Result<T> NotFound(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a result indicating that the requested resource was not found, with the specified <see cref="Error"/> objects and a default value.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the reason the resource was not found.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, a default value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.NotFound"/>.</returns>
    public new static Result<T> NotFound(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a result indicating that the requested resource was not found, with the provided exception message and a default value.
    /// </summary>
    /// <param name="exception">The exception indicating the reason the resource was not found.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, a default value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.NotFound"/>.</returns>
    public new static Result<T> NotFound(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.NotFound };
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
    /// Creates a result indicating a successful operation, with no value and no success message.
    /// </summary>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>true</c>, a default value, and the <c>Status</c> set to <see cref="ResultStatus.Success"/>.</returns>
    public new static Result<T> Success()
    {
        return new Result<T> { IsSuccess = true, Value = default, Status = ResultStatus.Success };
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
    /// Creates a result indicating a successful operation, with no value but a custom success message.
    /// </summary>
    /// <param name="successMessage">The success message indicating the result of the operation.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>true</c>, a default value, the provided success message, and the <c>Status</c> set to <see cref="ResultStatus.Success"/>.</returns>
    public new static Result<T> Success(string successMessage)
    {
        return new Result<T> { IsSuccess = true, Value = default, SuccessMessage = successMessage, Status = ResultStatus.Success };
    }

    /// <summary>
    /// Creates an unauthorized result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result{T}"/>.</returns>
    public static Result<T> Unauthorized(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unauthorized };
    }
    /// <summary>
    /// Creates an unauthorized result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errors">The error objects indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result{T}"/>.</returns>
    public static Result<T> Unauthorized(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an unauthorized result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="exception">The exception indicating the reason for the unauthorized operation.</param>
    /// <returns>An unauthorized <see cref="Result{T}"/>.</returns>
    public static Result<T> Unauthorized(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates a result indicating that the operation was unauthorized, with the provided error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the reason for the unauthorized operation.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided error messages, and the <c>Status</c> set to <see cref="ResultStatus.Unauthorized"/>.</returns>
    public new static Result<T> Unauthorized(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates a result indicating that the operation was unauthorized, with the provided error objects.
    /// </summary>
    /// <param name="errors">The <see cref="Error"/> objects indicating the reason for the unauthorized operation.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Unauthorized"/>.</returns>
    public new static Result<T> Unauthorized(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates a result indicating that the operation was unauthorized, with an error generated from an exception message.
    /// </summary>
    /// <param name="exception">The exception that caused the unauthorized operation, with its message used as the error description.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, an error generated from the exception message, and the <c>Status</c> set to <see cref="ResultStatus.Unauthorized"/>.</returns>
    public new static Result<T> Unauthorized(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an unavailable result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result{T}"/>.</returns>
    public static Result<T> Unavailable(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }
    /// <summary>
    /// Creates an unavailable result with the specified value and error objects.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errors">The error objects indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result{T}"/>.</returns>
    public static Result<T> Unavailable(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unavailable result with the specified value and exception.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="exception">The exception indicating the reason for the unavailable operation.</param>
    /// <returns>An unavailable <see cref="Result{T}"/>.</returns>
    public static Result<T> Unavailable(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unavailable, with the provided error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the reason the operation is unavailable.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided error messages, and the <c>Status</c> set to <see cref="ResultStatus.Unavailable"/>.</returns>
    public new static Result<T> Unavailable(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unavailable, with the provided error objects.
    /// </summary>
    /// <param name="errors">The <see cref="Error"/> objects indicating the reason the operation is unavailable.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Unavailable"/>.</returns>
    public new static Result<T> Unavailable(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unavailable, with an error generated from an exception message.
    /// </summary>
    /// <param name="exception">The exception that caused the operation to be unavailable, with its message used as the error description.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, an error generated from the exception message, and the <c>Status</c> set to <see cref="ResultStatus.Unavailable"/>.</returns>
    public new static Result<T> Unavailable(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unsupported result with the specified value and one or more error messages.
    /// </summary>
    /// <param name="value">The value associated with the unsupported result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="Result{T}"/>.</returns>
    public static Result<T> Unsupported(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unsupported };
    }
    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating an unsupported operation, with the provided value and errors.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the result, which may represent a default or relevant value in the context of the unsupported operation.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the reasons why the operation is unsupported.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, the provided errors, and the <c>Status</c> set to <see cref="ResultStatus.Unavailable"/>.</returns>
    public static Result<T> Unsupported(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates a result indicating an unsupported operation, with the provided value and exception.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the result.</param>
    /// <param name="exception">The exception describing the reason the operation is unsupported.</param>
    /// <returns>A <see cref="Result{T}"/> object with the status set to <see cref="ResultStatus.Unsupported"/>.</returns>
    public static Result<T> Unsupported(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unsupported, with the provided error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the reason the operation is unsupported.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided error messages, and the <c>Status</c> set to <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static Result<T> Unsupported(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unsupported, with the provided error objects.
    /// </summary>
    /// <param name="errors">The <see cref="Error"/> objects indicating the reason the operation is unsupported.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static Result<T> Unsupported(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates a result indicating that the operation is unsupported, with an error generated from an exception message.
    /// </summary>
    /// <param name="exception">The exception that caused the operation to be unsupported, with its message used as the error description.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, an error generated from the exception message, and the <c>Status</c> set to <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static Result<T> Unsupported(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating a validation failure, with custom error messages and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errorMessages">An array of error messages that describe the validation failures.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, errors generated from the provided messages with a <see cref="ErrorType.ValidationError"/> type, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result<T> ValidationError(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a <see cref="Result{T}"/> indicating a validation failure, with specified <see cref="Error"/> objects and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the validation failures.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result<T> ValidationError(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a result indicating a validation failure, with the provided exception and an associated value.
    /// </summary>
    /// <param name="value">The value associated with the validation error result.</param>
    /// <param name="exception">The exception indicating the validation failure.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, the provided value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result<T> ValidationError(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a result indicating a validation error, with the provided error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the reasons for the validation failure.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided error messages, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static Result<T> ValidationError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a result indicating a validation error, with the provided error objects.
    /// </summary>
    /// <param name="errors">The <see cref="Error"/> objects indicating the reasons for the validation failure.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static Result<T> ValidationError(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a result indicating a validation error, with an error generated from an exception message.
    /// </summary>
    /// <param name="exception">The exception that caused the validation error, with its message used as the error description.</param>
    /// <typeparam name="T">The type of the value associated with the operation result (defaulted to <c>default</c> in this method).</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, an error generated from the exception message, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static Result<T> ValidationError(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a result indicating a critical error, with custom error messages and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the critical error result.</param>
    /// <param name="errorMessages">An array of error messages that describe the critical error.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, errors generated from the provided messages with a <see cref="ErrorType.CriticalError"/> type, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result<T> CriticalError(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a result indicating a critical error, with the specified <see cref="Error"/> objects and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> to be associated with the critical error result.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the critical error.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the specified value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result<T> CriticalError(T? value, params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a result indicating a critical error, with the provided exception and an associated value.
    /// </summary>
    /// <param name="value">The value associated with the critical error result.</param>
    /// <param name="exception">The exception indicating the reason for the critical error.</param>
    /// <returns>A <see cref="Result{T}"/> with <c>IsSuccess</c> set to <c>false</c>, the provided value, an error message extracted from the exception, and the status set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result<T> CriticalError(T? value, Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = value, Errors = errors, Status = ResultStatus.CriticalError };
    }
    /// <summary>
    /// Creates a result indicating a critical error, with the provided error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the critical failure.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided error messages, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static Result<T> CriticalError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a result indicating a critical error, with the provided error objects.
    /// </summary>
    /// <param name="errors">The <see cref="Error"/> objects describing the critical failure.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, the provided <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static Result<T> CriticalError(params Error[] errors)
    {
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a result indicating a critical error, with an error generated from an exception message.
    /// </summary>
    /// <param name="exception">The exception that caused the critical error, with its message used as the error description.</param>
    /// <returns>A <see cref="Result{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, no value, an error generated from the exception message, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static Result<T> CriticalError(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result<T> { IsSuccess = false, Value = default, Errors = errors, Status = ResultStatus.CriticalError };
    }
}
