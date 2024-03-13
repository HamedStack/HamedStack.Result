namespace HamedStack.Result;

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
    /// Indicates a general error occurred during the operation.
    /// </summary>
    Error,

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
    Unsupported
}
