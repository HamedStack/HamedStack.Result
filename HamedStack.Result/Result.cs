// ReSharper disable UnusedMember.Global

using System.Text.Json.Serialization;

namespace HamedStack.Result;
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
    /// Gets the status of the result, indicating success or the type of failure.
    /// </summary>
    /// <value>The status of the result.</value>
    [JsonInclude]
    public ResultStatus Status { get; protected set; } = ResultStatus.Success;

    /// <summary>
    /// Gets a value indicating whether the operation succeeded.
    /// </summary>
    /// <value><c>true</c> if the operation was successful; otherwise, <c>false</c>.</value>
    public bool IsSuccess { get; protected set; } = true;

    /// <summary>
    /// Gets an array of error messages associated with a failed operation.
    /// </summary>
    /// <value>An array of error messages.</value>
    public string[] ErrorMessages { get; protected set; } = new string[] { };

    /// <summary>
    /// Gets the success message for a successful operation.
    /// </summary>
    /// <value>The success message.</value>
    public string SuccessMessage { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a dictionary containing additional metadata associated with the result.
    /// </summary>
    /// <value>The metadata dictionary.</value>
    [JsonInclude]
    public IDictionary<string, object?> Metadata { get; protected set; } = new Dictionary<string, object?>();

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
    /// Creates an error result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages.</param>
    /// <returns>An error <see cref="Result"/>.</returns>
    public static Result Error(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Error };
    }

    /// <summary>
    /// Creates a forbidden result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is forbidden.</param>
    /// <returns>A forbidden <see cref="Result"/>.</returns>
    public static Result Forbidden(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Forbidden };
    }

    /// <summary>
    /// Creates an unauthorized result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is unauthorized.</param>
    /// <returns>An unauthorized <see cref="Result"/>.</returns>
    public static Result Unauthorized(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Unauthorized };
    }

    /// <summary>
    /// Creates an invalid result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is invalid.</param>
    /// <returns>An invalid <see cref="Result"/>.</returns>
    public static Result Invalid(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Invalid };
    }

    /// <summary>
    /// Creates a not found result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating the target of the operation was not found.</param>
    /// <returns>A not found <see cref="Result"/>.</returns>
    public static Result NotFound(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.NotFound };
    }

    /// <summary>
    /// Creates a conflict result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation results in a conflict.</param>
    /// <returns>A conflict <see cref="Result"/>.</returns>
    public static Result Conflict(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Conflict };
    }

    /// <summary>
    /// Creates an unavailable result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is currently unavailable.</param>
    /// <returns>An unavailable <see cref="Result"/>.</returns>
    public static Result Unavailable(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Unavailable };
    }

    /// <summary>
    /// Creates an unsupported result with one or more error messages.
    /// </summary>
    /// <param name="errorMessages">The error messages indicating why the operation is unsupported.</param>
    /// <returns>An unsupported <see cref="Result"/>.</returns>
    public static Result Unsupported(params string[] errorMessages)
    {
        return new Result { IsSuccess = false, ErrorMessages = errorMessages, Status = ResultStatus.Unsupported };
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
