namespace HamedStack.TheResult;

/// <summary>
/// Represents the type of error that occurred during an operation.
/// </summary>
public enum ErrorType
{
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