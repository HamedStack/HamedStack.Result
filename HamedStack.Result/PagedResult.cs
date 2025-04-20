// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.TheResult;
/// <summary>
/// Represents a paged outcome of an operation with a specific return type, extending <see cref="Result{T}"/> with pagination details.
/// </summary>
/// <typeparam name="T">The type of the value returned by the operation.</typeparam>
public class PagedResult<T> : Result<T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedResult{T}"/> class. Protected to prevent instantiation outside of factory methods.
    /// </summary>
    protected PagedResult()
    {
    }

    /// <summary>
    /// Gets a value indicating whether this paged result contains pagination information.
    /// </summary>
    /// <value><c>true</c> if this instance contains pagination information; otherwise, <c>false</c>.</value>
    public bool HasPagedInfo => PagedInfo is not null;

    /// <summary>
    /// Gets or sets the pagination information associated with the paged result.
    /// </summary>
    /// <value>The pagination information.</value>
    [JsonInclude] public PagedInfo? PagedInfo { get; set; }
    /// <summary>
    /// Creates a conflict result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Conflict(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status and the provided error messages.</returns>

    public new static PagedResult<T> Conflict(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status and the provided error messages.</returns>
    public new static PagedResult<T> Conflict(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a conflict result with the specified value and one or more errors, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="errors">The errors indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Conflict(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status and the provided errors.</returns>
    public new static PagedResult<T> Conflict(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned in the result.</param>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status, the provided value, and the provided errors.</returns>
    public new static PagedResult<T> Conflict(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status and the provided errors.</returns>
    public new static PagedResult<T> Conflict(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a conflict result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the conflict result.</param>
    /// <param name="exception">The exception that caused the conflict.</param>
    /// <returns>A conflict <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Conflict(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a conflict, with the exception message as an error.
    /// </summary>
    /// <param name="exception">The exception describing the conflict.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Conflict"/> status and the exception message as an error.</returns>
    public new static PagedResult<T> Conflict(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Conflict,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a failure result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the error result.</param>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Failure(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status and the provided error messages.</returns>
    public new static PagedResult<T> Failure(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status and the provided error messages.</returns>
    public new static PagedResult<T> Failure(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a failure result with the specified value and one or more errors, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the error result.</param>
    /// <param name="errors">The errors indicating the failure.</param>
    /// <returns>A failure <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Failure(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status and the provided errors.</returns>
    public new static PagedResult<T> Failure(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned in the result.</param>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status, the provided value, and the provided errors.</returns>
    public new static PagedResult<T> Failure(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status and the provided errors.</returns>
    public new static PagedResult<T> Failure(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a failure result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the error result.</param>
    /// <param name="exception">The exception that caused the failure.</param>
    /// <returns>A failure <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Failure(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating a failure, with the exception message as an error.
    /// </summary>
    /// <param name="exception">The exception describing the failure.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Failure"/> status and the exception message as an error.</returns>
    public new static PagedResult<T> Failure(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Failure,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a forbidden result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Forbidden(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status and the provided error messages.</returns>

    public new static PagedResult<T> Forbidden(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the specified error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status and the provided error messages.</returns>
    public new static PagedResult<T> Forbidden(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a forbidden result with the specified value and one or more errors, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="errors">The errors indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Forbidden(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status and the provided errors.</returns>
    public new static PagedResult<T> Forbidden(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned in the result.</param>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status, the provided value, and the provided errors.</returns>
    public new static PagedResult<T> Forbidden(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the specified errors.
    /// </summary>
    /// <param name="errors">The collection of <see cref="Error"/> objects describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status and the provided errors.</returns>
    public new static PagedResult<T> Forbidden(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a forbidden result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the forbidden result.</param>
    /// <param name="exception">The exception that caused the forbidden result.</param>
    /// <returns>A forbidden <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Forbidden(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a new <see cref="PagedResult{T}"/> indicating that access is forbidden, with the exception message as an error.
    /// </summary>
    /// <param name="exception">The exception describing the forbidden access.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with the <see cref="ResultStatus.Forbidden"/> status and the exception message as an error.</returns>
    public new static PagedResult<T> Forbidden(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Forbidden,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates an invalid result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Invalid(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/> and the specified error messages.</returns>
    public new static PagedResult<T> Invalid(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An enumerable collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/> and the specified error messages.</returns>
    public new static PagedResult<T> Invalid(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates an invalid result with the specified value and one or more errors, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="errors">The errors indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Invalid(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and an array of errors.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/> and the specified errors.</returns>
    public new static PagedResult<T> Invalid(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned with the result.</param>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/>, the specified value, and the specified errors.</returns>
    public new static PagedResult<T> Invalid(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and the specified errors.
    /// </summary>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/> and the specified errors.</returns>
    public new static PagedResult<T> Invalid(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates an invalid result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the invalid result.</param>
    /// <param name="exception">The exception that caused the invalid result.</param>
    /// <returns>An invalid <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Invalid(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Invalid"/> and an exception as the error.
    /// </summary>
    /// <param name="exception">An exception to create an error message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Invalid"/> and an error message derived from the exception.</returns>
    public new static PagedResult<T> Invalid(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Invalid,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a not found result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> NotFound(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/> and the specified error messages.</returns>
    public new static PagedResult<T> NotFound(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An enumerable collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/> and the specified error messages.</returns>
    public new static PagedResult<T> NotFound(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a not found result with the specified value and one or more errors, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="errors">The errors indicating why the target was not found.</param>
    /// <returns>A not found <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> NotFound(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and an array of errors.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/> and the specified errors.</returns>
    public new static PagedResult<T> NotFound(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned with the result.</param>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/>, the specified value, and the specified errors.</returns>
    public new static PagedResult<T> NotFound(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and the specified errors.
    /// </summary>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/> and the specified errors.</returns>
    public new static PagedResult<T> NotFound(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a not found result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the not found result.</param>
    /// <param name="exception">The exception that caused the not found result.</param>
    /// <returns>A not found <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> NotFound(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.NotFound"/> and an exception as the error.
    /// </summary>
    /// <param name="exception">An exception to create an error message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.NotFound"/> and an error message derived from the exception.</returns>
    public new static PagedResult<T> NotFound(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.NotFound,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a success result with pagination information.
    /// </summary>
    /// <param name="pagedInfo">The pagination information.</param>
    /// <returns>A success <see cref="PagedResult{T}"/> with the specified pagination information.</returns>
    public static PagedResult<T> Success(PagedInfo pagedInfo)
    {
        return new PagedResult<T>
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            Value = default,
            PagedInfo = pagedInfo
        };
    }

    /// <summary>
    /// Creates a success result with default pagination information.
    /// </summary>
    /// <returns>A success <see cref="PagedResult{T}"/> with default pagination information.</returns>
    public new static PagedResult<T> Success()
    {
        return new PagedResult<T>
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            Value = default,
            PagedInfo = new PagedInfo()
        };
    }

    /// <summary>
    /// Creates a success result with the specified value, pagination information, and success message.
    /// </summary>
    /// <param name="value">The value to return with the result.</param>
    /// <param name="pagedInfo">The pagination information.</param>
    /// <param name="successMessage">The success message.</param>
    /// <returns>A success <see cref="PagedResult{T}"/> with the specified value, pagination information, and success message.</returns>
    public static PagedResult<T> Success(T? value, PagedInfo pagedInfo, string successMessage = "")
    {
        return new PagedResult<T>
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            SuccessMessage = successMessage,
            Value = value,
            PagedInfo = pagedInfo
        };
    }
    /// <summary>
    /// Creates a success result with the specified success message.
    /// </summary>
    /// <param name="successMessage">The success message.</param>
    /// <returns>A success <see cref="PagedResult{T}"/> with the specified success message and default pagination information.</returns>
    public new static PagedResult<T> Success(string successMessage)
    {
        return new PagedResult<T>
        {
            IsSuccess = true,
            Status = ResultStatus.Success,
            SuccessMessage = successMessage,
            Value = default,
            PagedInfo = new PagedInfo()
        };
    }
    /// <summary>
    /// Creates an unauthorized result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Unauthorized(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/> and the specified error messages.</returns>
    public new static PagedResult<T> Unauthorized(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An enumerable collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/> and the specified error messages.</returns>
    public new static PagedResult<T> Unauthorized(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates an unauthorized result with the specified value and one or more error objects, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="errors">The error objects indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Unauthorized(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and an array of errors.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/> and the specified errors.</returns>
    public new static PagedResult<T> Unauthorized(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned with the result.</param>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/>, the specified value, and the specified errors.</returns>
    public new static PagedResult<T> Unauthorized(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and the specified errors.
    /// </summary>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/> and the specified errors.</returns>
    public new static PagedResult<T> Unauthorized(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates an unauthorized result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unauthorized result.</param>
    /// <param name="exception">The exception to associate with the error.</param>
    /// <returns>An unauthorized <see cref="PagedResult{T}"/> with the exception.</returns>
    public new static PagedResult<T> Unauthorized(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unauthorized"/> and an exception as the error.
    /// </summary>
    /// <param name="exception">An exception to create an error message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unauthorized"/> and an error message derived from the exception.</returns>
    public new static PagedResult<T> Unauthorized(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unauthorized,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates an unavailable result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Unavailable(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/> and the specified error messages.</returns>
    public new static PagedResult<T> Unavailable(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and error messages.
    /// </summary>
    /// <param name="errorMessages">An enumerable collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/> and the specified error messages.</returns>
    public new static PagedResult<T> Unavailable(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates an unavailable result with the specified value and one or more error objects, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="errors">The error objects indicating why the operation is unavailable.</param>
    /// <returns>An unavailable <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Unavailable(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and an array of errors.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/> and the specified errors.</returns>
    public new static PagedResult<T> Unavailable(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }

    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and the specified value and errors.
    /// </summary>
    /// <param name="value">The value to be returned with the result.</param>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/>, the specified value, and the specified errors.</returns>
    public new static PagedResult<T> Unavailable(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and the specified errors.
    /// </summary>
    /// <param name="errors">An enumerable collection of <see cref="Error"/> objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/> and the specified errors.</returns>
    public new static PagedResult<T> Unavailable(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates an unavailable result with the specified value and an exception, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unavailable result.</param>
    /// <param name="exception">The exception to associate with the error.</param>
    /// <returns>An unavailable <see cref="PagedResult{T}"/> with the exception.</returns>
    public new static PagedResult<T> Unavailable(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unavailable"/> and an exception as the error.
    /// </summary>
    /// <param name="exception">An exception to create an error message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance with status <see cref="ResultStatus.Unavailable"/> and an error message derived from the exception.</returns>
    public new static PagedResult<T> Unavailable(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unavailable,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates an unsupported result with the specified value and one or more error messages, without pagination information.
    /// </summary>
    /// <param name="value">The value associated with the unsupported result.</param>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="PagedResult{T}"/>.</returns>
    public new static PagedResult<T> Unsupported(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">A collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating that the operation is unsupported, with a specified value and an array of errors.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with this result, which might be the default or a relevant value in the context of the unsupported operation.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects describing the reasons the operation is unsupported.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.Unsupported"/>, the provided value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and the specified errors.</returns>
    public new static PagedResult<T> Unsupported(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with the given error objects.
    /// </summary>
    /// <param name="errors">An array of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with the given value and error objects.
    /// </summary>
    /// <param name="value">The value to return.</param>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with the given error objects.
    /// </summary>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating that the operation is unsupported, with a specified value and an exception.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with this result, which might be the default or a relevant value in the context of the unsupported operation.</param>
    /// <param name="exception">The exception that describes why the operation is unsupported.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.Unsupported"/>, the provided value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and an error generated from the exception's message.</returns>
    public new static PagedResult<T> Unsupported(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating an unsupported status with an exception message.
    /// </summary>
    /// <param name="exception">The exception to extract the message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.Unsupported"/>.</returns>
    public new static PagedResult<T> Unsupported(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.Unsupported,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a validation failure, with custom error messages and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errorMessages">An array of error messages that describe the validation failures.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>, the specified value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and errors generated from the provided messages with a ValidationError type.</returns>
    public new static PagedResult<T> ValidationError(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">A collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a validation failure, with specified <see cref="Error"/> objects and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the validation failure result, potentially representing the attempted input.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the validation failures.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>, the specified value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and the provided <see cref="Error"/> objects.</returns>
    public new static PagedResult<T> ValidationError(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with the given error objects.
    /// </summary>
    /// <param name="errors">An array of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with the given value and error objects.
    /// </summary>
    /// <param name="value">The value to return.</param>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with the given error objects.
    /// </summary>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a validation failure, with a specified value and an exception.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with this result, which might be the default or a relevant value in the context of the validation failure.</param>
    /// <param name="exception">The exception that describes the validation failure.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>, the provided value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and an error generated from the exception's message.</returns>
    public new static PagedResult<T> ValidationError(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a validation error status with an exception message.
    /// </summary>
    /// <param name="exception">The exception to extract the message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.ValidationError"/>.</returns>
    public new static PagedResult<T> ValidationError(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.ValidationError,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a critical error, with specified error messages and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the critical error result.</param>
    /// <param name="errorMessages">An array of error messages that describe the critical errors.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>, the specified value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and errors generated from the provided messages with a CriticalError type.</returns>
    public new static PagedResult<T> CriticalError(T? value, params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with the given error messages.
    /// </summary>
    /// <param name="errorMessages">A collection of error messages.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(IEnumerable<string> errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a critical error, with specified <see cref="Error"/> objects and an associated value.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with the critical error result.</param>
    /// <param name="errors">An array of <see cref="Error"/> objects describing the critical errors.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>, the specified value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and the provided <see cref="Error"/> objects.</returns>
    public new static PagedResult<T> CriticalError(T? value, params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = value,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with the given error objects.
    /// </summary>
    /// <param name="errors">An array of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(params Error[] errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = default,
            PagedInfo = null,
            Errors = errors
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with the given value and error objects.
    /// </summary>
    /// <param name="value">The value to return.</param>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(T? value, IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = value,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with the given error objects.
    /// </summary>
    /// <param name="errors">A collection of error objects.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(IEnumerable<Error> errors)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = default,
            PagedInfo = null,
            Errors = errors.ToArray()
        };
    }
    /// <summary>
    /// Creates a new <see cref="PagedResult{T}"/> indicating a critical error, with a specified value and an exception.
    /// </summary>
    /// <param name="value">The value of type <typeparamref name="T"/> associated with this result, which might be the default or a relevant value in the context of the critical error.</param>
    /// <param name="exception">The exception that describes why the operation encountered a critical error.</param>
    /// <typeparam name="T">The type of the value associated with the operation result.</typeparam>
    /// <returns>A <see cref="PagedResult{T}"/> object with <c>IsSuccess</c> set to <c>false</c>, the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>, the provided value, no pagination information (<c>PagedInfo</c> set to <c>null</c>), and an error generated from the exception's message.</returns>
    public new static PagedResult<T> CriticalError(T? value, Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = value,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Returns a <see cref="PagedResult{T}"/> indicating a critical error status with an exception message.
    /// </summary>
    /// <param name="exception">The exception to extract the message from.</param>
    /// <returns>A <see cref="PagedResult{T}"/> with a status of <see cref="ResultStatus.CriticalError"/>.</returns>
    public new static PagedResult<T> CriticalError(Exception exception)
    {
        return new PagedResult<T>
        {
            IsSuccess = false,
            Status = ResultStatus.CriticalError,
            Value = default,
            PagedInfo = null,
            Errors = [new Error(exception.Message)]
        };
    }
    /// <summary>
    /// Creates a <see cref="Result"/> instance representing a successful operation with no content to return.
    /// Typically used for operations that do not require a response body, such as DELETE actions.
    /// </summary>
    /// <returns>A <see cref="Result"/> with <see cref="Result.IsSuccess"/> set to true and <see cref="Result.Status"/> set to <see cref="ResultStatus.NoContent"/>.</returns>
    public new static PagedResult<T> NoContent()
    {
        return new PagedResult<T> { IsSuccess = true, Status = ResultStatus.NoContent };
    }
}