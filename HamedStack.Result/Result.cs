// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.TheResult;

/// <summary>
/// Represents the outcome of an operation, providing a standardized way to communicate success, failure, and related metadata.
/// </summary>
public class Result
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Result"/> class. Protected to prevent instantiation outside of factory methods.
    /// </summary>
    protected Result() { }

    /// <summary>
    /// Gets an array of <see cref="Error"/> instances associated with a failed operation. Each <see cref="Error"/> in the array provides details about a specific error that occurred during the operation.
    /// </summary>
    /// <value>An array of <see cref="Error"/> instances.</value>
    public Error[] Errors { get; protected set; } = [];

    /// <summary>
    /// Gets a value indicating whether the result has any metadata associated with it.
    /// </summary>
    /// <value><c>true</c> if the result has metadata; otherwise, <c>false</c>.</value>
    public bool HasMetadata => Metadata.Count > 0;

    /// <summary>
    /// Gets a value indicating whether the operation succeeded.
    /// </summary>
    /// <value><c>true</c> if the operation was successful; otherwise, <c>false</c>.</value>
    public bool IsSuccess { get; protected set; } = true;

    /// <summary>
    /// Gets the correlation ID that uniquely identifies this result across systems.
    /// This can be used for tracking and debugging operations.
    /// </summary>
    /// <value>A string representing the correlation ID.</value>
    public string? CorrelationId { get; set; }

    /// <summary>
    /// Gets a dictionary containing additional metadata associated with the result.
    /// </summary>
    /// <value>The metadata dictionary.</value>
    [JsonInclude]
    public IDictionary<string, object?> Metadata { get; protected set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Gets the status of the result, indicating success or the type of failure.
    /// </summary>
    /// <value>The status of the result.</value>
    [JsonInclude]
    public ResultStatus Status { get; protected set; } = ResultStatus.Success;
    /// <summary>
    /// Gets the success message for a successful operation.
    /// </summary>
    /// <value>The success message.</value>
    public string SuccessMessage { get; protected set; } = string.Empty;
    /// <summary>
    /// Creates a conflict result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="Result"/>.</returns>
    public static Result Conflict(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating a conflict in the operation, populated with specified errors.
    /// This method is used when an operation cannot proceed because of conflicting state or resources.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances describing specific conflicts encountered.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent a conflict state, including the provided error details.</returns>
    public static Result Conflict(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates a conflict result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the conflict.</param>
    /// <returns>A conflict <see cref="Result"/>.</returns>
    public static Result Conflict(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates an failure result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="Result"/>.</returns>
    public static Result Failure(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates an failure <see cref="Result"/> instance with the specified errors, indicating a failed operation.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances representing the errors encountered during the operation.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent an error state, including the provided error details.</returns>
    public static Result Failure(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a failure result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the failure.</param>
    /// <returns>A failure <see cref="Result"/>.</returns>
    public static Result Failure(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Failure };
    }

    /// <summary>
    /// Creates a forbidden result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result"/>.</returns>
    public static Result Forbidden(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> instance representing a forbidden operation, populated with the specified errors.
    /// This method is typically used when an operation is not allowed due to security or permission issues, and it provides details about the reasons through the specified errors.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances representing the specific reasons why the operation is forbidden.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent a forbidden state, including the provided error details.</returns>
    public static Result Forbidden(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates a forbidden result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the forbidden operation.</param>
    /// <returns>A forbidden <see cref="Result"/>.</returns>
    public static Result Forbidden(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates an invalid result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="Result"/>.</returns>
    public static Result Invalid(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating an invalid operation, populated with specified errors.
    /// This method is used when an operation is rejected due to validation failures or other rules that render the request invalid.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances describing specific reasons for the operation's invalidity.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent an invalid state, including the provided error details.</returns>
    public static Result Invalid(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates an invalid result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the invalid operation.</param>
    /// <returns>An invalid <see cref="Result"/>.</returns>
    public static Result Invalid(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a not found result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="Result"/>.</returns>
    public static Result NotFound(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating that the requested resource was not found, populated with specified errors.
    /// This method is typically used when an operation cannot be completed because a necessary resource is missing.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances that provide details about what was not found.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent a not found state, including the provided error details.</returns>
    public static Result NotFound(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a not found result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the resource not found.</param>
    /// <returns>A not found <see cref="Result"/>.</returns>
    public static Result NotFound(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a success result.
    /// </summary>
    /// <returns>A success <see cref="Result"/>.</returns>
    public static Result Success()
    {
        return new Result { IsSuccess = true, Status = ResultStatus.Success };
    }

    /// <summary>
    /// Creates a success result with a success message.
    /// </summary>
    /// <param name="successMessage">The success message.</param>
    /// <returns>A success <see cref="Result"/> with a success message.</returns>
    public static Result Success(string successMessage)
    {
        return new Result { IsSuccess = true, Status = ResultStatus.Success, SuccessMessage = successMessage };
    }
    /// <summary>
    /// Creates an unauthorized result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result"/>.</returns>
    public static Result Unauthorized(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unauthorized };
    }
    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating an unauthorized operation, populated with specified errors.
    /// This method is used when an operation cannot proceed because the requester lacks proper authentication.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances describing specific authentication failures.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent an unauthorized state, including the provided error details.</returns>
    public static Result Unauthorized(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an unauthorized result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the unauthorized operation.</param>
    /// <returns>An unauthorized <see cref="Result"/>.</returns>
    public static Result Unauthorized(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an unavailable result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result"/>.</returns>
    public static Result Unavailable(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unavailable };
    }
    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating that the service or resource is currently unavailable, populated with specified errors.
    /// This method can be used during maintenance periods or when a service is down for any reason.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances explaining the reasons for the unavailability.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent an unavailable state, including the provided error details.</returns>
    public static Result Unavailable(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unavailable result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the unavailability.</param>
    /// <returns>An unavailable <see cref="Result"/>.</returns>
    public static Result Unavailable(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unsupported result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="Result"/>.</returns>
    public static Result Unsupported(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unsupported };
    }
    /// <summary>
    /// Creates a <see cref="Result"/> instance indicating that the operation is unsupported, populated with specified errors.
    /// This method is used when an operation cannot be completed because it is not supported by the system, perhaps due to being obsolete or not yet implemented.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> instances describing specific reasons why the operation is unsupported.</param>
    /// <returns>A <see cref="Result"/> instance configured to represent an unsupported state, including the provided error details.</returns>
    public static Result Unsupported(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates an unsupported result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the unsupported operation.</param>
    /// <returns>An unsupported <see cref="Result"/>.</returns>
    public static Result Unsupported(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.Unsupported };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating a validation failure with custom error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the validation failures.</param>
    /// <returns>A <see cref="Result"/> object with <c>IsSuccess</c> set to <c>false</c>, containing the specified error messages wrapped in <see cref="Error"/> objects with a <see cref="ErrorType.ValidationError"/> type, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result ValidationError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating a validation failure with specified <see cref="Error"/> objects.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the validation failures.</param>
    /// <returns>A <see cref="Result"/> object with <c>IsSuccess</c> set to <c>false</c>, containing the specified <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.ValidationError"/>.</returns>
    public static Result ValidationError(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a validation error result using an exception to generate error details.
    /// </summary>
    /// <param name="exception">The exception whose message describes the validation error.</param>
    /// <returns>A validation error <see cref="Result"/>.</returns>
    public static Result ValidationError(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.ValidationError };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating a critical error with custom error messages.
    /// </summary>
    /// <param name="errorMessages">An array of error messages that describe the critical errors encountered.</param>
    /// <returns>A <see cref="Result"/> object with <c>IsSuccess</c> set to <c>false</c>, containing the specified error messages wrapped in <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result CriticalError(params string[] errorMessages)
    {
        var errors = errorMessages.Select(e => new Error(e)).ToArray();
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating a critical error with specified <see cref="Error"/> objects.
    /// </summary>
    /// <param name="errors">An array of <see cref="Error"/> objects that describe the critical errors encountered.</param>
    /// <returns>A <see cref="Result"/> object with <c>IsSuccess</c> set to <c>false</c>, containing the specified <see cref="Error"/> objects, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result CriticalError(params Error[] errors)
    {
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> indicating a critical error caused by an exception.
    /// </summary>
    /// <param name="exception">The exception that triggered the critical error.</param>
    /// <returns>A <see cref="Result"/> object with <c>IsSuccess</c> set to <c>false</c>, containing an <see cref="Error"/> object with the exception's message, and the <c>Status</c> set to <see cref="ResultStatus.CriticalError"/>.</returns>
    public static Result CriticalError(Exception exception)
    {
        var errors = new[] { new Error(exception.Message) };
        return new Result { IsSuccess = false, Errors = errors, Status = ResultStatus.CriticalError };
    }

    /// <summary>
    /// Creates a <see cref="Result"/> instance representing a successful operation with no content to return.
    /// Typically used for operations that do not require a response body, such as DELETE actions.
    /// </summary>
    /// <returns>A <see cref="Result"/> with <see cref="Result.IsSuccess"/> set to true and <see cref="Result.Status"/> set to <see cref="ResultStatus.NoContent"/>.</returns>
    public static Result NoContent()
    {
        return new Result { IsSuccess = true, Status = ResultStatus.NoContent };
    }

    /// <summary>
    /// Adds or updates a key-value pair in the result's metadata.
    /// </summary>
    /// <param name="key">The key of the metadata item.</param>
    /// <param name="value">The value of the metadata item.</param>
    public void AddOrUpdateMetadata(string key, object? value)
    {
        Metadata[key] = value;
    }
}
