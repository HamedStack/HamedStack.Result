namespace HamedStack.TheResult;

/// <summary>
/// Represents an error with a message and a metadata dictionary. 
/// This class provides functionalities to instantiate errors with a message and manipulate error metadata.
/// </summary>
public class Error
{
    /// <summary>
    /// Protected constructor to prevent instantiation without providing a message.
    /// </summary>
    protected Error() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class with the specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public Error(string message)
    {
        Message = message;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class with the specified error message and code.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="code">The code associated with the error.</param>
    public Error(string message, string code)
    {
        Message = message;
        Code = code;
    }

    /// <summary>
    /// Gets or sets the message that describes the current error.
    /// </summary>
    /// <value>The error message.</value>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Gets or sets the code associated with the error.
    /// </summary>
    /// <value>The error code.</value>
    public string? Code { get; set; }

    /// <summary>
    /// Gets the metadata associated with the error, providing additional information about the error.
    /// The metadata is a dictionary where each key-value pair represents a piece of additional information.
    /// </summary>
    /// <value>The metadata dictionary.</value>
    public IDictionary<string, object?> Metadata { get; protected set; } = new Dictionary<string, object?>();

    /// <summary>
    /// Adds a new key-value pair to the metadata dictionary or updates the value if the key already exists.
    /// </summary>
    /// <param name="key">The key to add or update in the metadata dictionary.</param>
    /// <param name="value">The value to set for the specified key.</param>
    public void AddOrUpdateMetadata(string key, object? value)
    {
        Metadata[key] = value;
    }
}
