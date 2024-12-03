namespace HamedStack.TheResult;

/// <summary>
/// Defines the possible result statuses that can be returned from an operation.
/// </summary>
public enum ResultStatus
{
    /// <summary>
    /// Indicates that the operation was successful.
    /// </summary>
    Success,

    /// <summary>
    /// Indicates a general failure occurred during the operation.
    /// </summary>
    Failure,

    /// <summary>
    /// Indicates the operation was forbidden due to lack of permissions.
    /// </summary>
    Forbidden,

    /// <summary>
    /// Indicates the user is not authorized to perform the operation.
    /// </summary>
    Unauthorized,

    /// <summary>
    /// Indicates the operation was invalid, possibly due to incorrect input.
    /// </summary>
    Invalid,

    /// <summary>
    /// Indicates the requested resource was not found.
    /// </summary>
    NotFound,

    /// <summary>
    /// Indicates the operation caused a conflict, such as a duplicate entry.
    /// </summary>
    Conflict,

    /// <summary>
    /// Indicates the service or resource is currently unavailable.
    /// </summary>
    Unavailable,

    /// <summary>
    /// Indicates the operation is unsupported or not implemented.
    /// </summary>
    Unsupported,

    /// <summary>
    /// Indicates an error due to a data validation failure.
    /// </summary>
    ValidationError,

    /// <summary>
    /// Indicates a critical error occurred, requiring immediate attention.
    /// This may include system-level failures, unhandled exceptions, or severe infrastructure issues.
    /// </summary>
    CriticalError,

    /// <summary>
    /// Indicates that the operation was successful but there is no content to return.
    /// This is typically used for operations like DELETE or actions that do not return data.
    /// </summary>
    NoContent
}