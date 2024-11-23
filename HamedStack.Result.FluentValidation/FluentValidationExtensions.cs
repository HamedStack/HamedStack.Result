using FluentValidation.Results;

namespace HamedStack.TheResult.FluentValidation;

/// <summary>
/// Provides extension methods for FluentValidation, enhancing its integration with other parts of the application.
/// This static class offers a set of utilities designed to convert FluentValidation's validation results into custom formats,
/// facilitate easier error handling, and enhance the usability of FluentValidation within different application layers.
/// </summary>
public static class FluentValidationExtensions
{
    /// <summary>
    /// Converts a ValidationResult into a non-generic Result object, optionally including a success message.
    /// </summary>
    /// <param name="validationResult">The ValidationResult object to convert.</param>
    /// <param name="successMessage">An optional success message to include if the ValidationResult is valid. Default is an empty string.</param>
    /// <returns>A Result object indicating success with a message if the ValidationResult is valid, or containing errors if not.</returns>
    public static Result ToResult(this ValidationResult validationResult, string successMessage = "")
    {
        if (validationResult.IsValid)
            return Result.Success(successMessage);

        var errorsCount = validationResult.Errors.Count;
        var errors = new Error[errorsCount];
        for (var i = 0; i < errors.Length; i++)
        {
            errors[i] = new Error(validationResult.Errors[i].ErrorMessage, validationResult.Errors[i].ErrorCode);

            errors[i].AddOrUpdateMetadata("Severity", validationResult.Errors[i].Severity);
            errors[i].AddOrUpdateMetadata("PropertyName", validationResult.Errors[i].PropertyName);
            errors[i].AddOrUpdateMetadata("AttemptedValue", validationResult.Errors[i].AttemptedValue);
        }
        return Result.ValidationError(errors);
    }

    /// <summary>
    /// Converts a ValidationResult into a generic Result object, optionally including a success message and a value of type T.
    /// </summary>
    /// <typeparam name="T">The type of the value to include in the Result object.</typeparam>
    /// <param name="validationResult">The ValidationResult object to convert.</param>
    /// <param name="value">The value of type T to include in the Result if the ValidationResult is valid.</param>
    /// <param name="successMessage">An optional success message to include if the ValidationResult is valid. Default is an empty string.</param>
    /// <returns>A Result object of type T indicating success with a value and message if the ValidationResult is valid, or containing errors if not.</returns>
    public static Result<T> ToResult<T>(this ValidationResult validationResult, T? value, string successMessage = "")
    {
        if (validationResult.IsValid)
            return Result<T>.Success(value, successMessage);

        var errorsCount = validationResult.Errors.Count;
        var errors = new Error[errorsCount];
        for (var i = 0; i < errors.Length; i++)
        {
            errors[i] = new Error(validationResult.Errors[i].ErrorMessage, validationResult.Errors[i].ErrorCode);

            errors[i].AddOrUpdateMetadata("Severity", validationResult.Errors[i].Severity);
            errors[i].AddOrUpdateMetadata("PropertyName", validationResult.Errors[i].PropertyName);
            errors[i].AddOrUpdateMetadata("AttemptedValue", validationResult.Errors[i].AttemptedValue);
        }
        return Result<T>.ValidationError(value, errors);
    }

    /// <summary>
    /// Converts a ValidationResult into a generic Result object.
    /// </summary>
    /// <typeparam name="T">The type of the value to include in the Result object.</typeparam>
    /// <param name="validationResult">The ValidationResult object to convert.</param>
    /// <returns>A Result object of type T indicating success with a value and message if the ValidationResult is valid, or containing errors if not.</returns>
    public static Result<T> ToResult<T>(this ValidationResult validationResult)
    {
        if (validationResult.IsValid)
            return Result<T>.Success(default, string.Empty);

        var errorsCount = validationResult.Errors.Count;
        var errors = new Error[errorsCount];
        for (var i = 0; i < errors.Length; i++)
        {
            errors[i] = new Error(validationResult.Errors[i].ErrorMessage, validationResult.Errors[i].ErrorCode);

            errors[i].AddOrUpdateMetadata("Severity", validationResult.Errors[i].Severity);
            errors[i].AddOrUpdateMetadata("PropertyName", validationResult.Errors[i].PropertyName);
            errors[i].AddOrUpdateMetadata("AttemptedValue", validationResult.Errors[i].AttemptedValue);
        }
        return Result<T>.ValidationError(default, errors);
    }

    /// <summary>
    /// Converts a ValidationResult into a PagedResult object of type T, optionally including a success message, a value of type T, and paging information.
    /// </summary>
    /// <typeparam name="T">The type of the value to include in the PagedResult.</typeparam>
    /// <param name="validationResult">The ValidationResult object to convert.</param>
    /// <param name="value">The value of type T to include in the PagedResult if the ValidationResult is valid.</param>
    /// <param name="pagedInfo">The paging information to include in the PagedResult.</param>
    /// <param name="successMessage">An optional success message to include if the ValidationResult is valid. Default is an empty string.</param>
    /// <returns>A PagedResult object of type T indicating success with a value, paging information, and message if the ValidationResult is valid, or containing errors if not.</returns>
    public static PagedResult<T> ToResult<T>(this ValidationResult validationResult, T? value, PagedInfo pagedInfo, string successMessage = "")
    {
        if (validationResult.IsValid)
            return PagedResult<T>.Success(value, pagedInfo, successMessage);

        var errorsCount = validationResult.Errors.Count;
        var errors = new Error[errorsCount];
        for (var i = 0; i < errors.Length; i++)
        {
            errors[i] = new Error(validationResult.Errors[i].ErrorMessage, validationResult.Errors[i].ErrorCode);

            errors[i].AddOrUpdateMetadata("Severity", validationResult.Errors[i].Severity);
            errors[i].AddOrUpdateMetadata("PropertyName", validationResult.Errors[i].PropertyName);
            errors[i].AddOrUpdateMetadata("AttemptedValue", validationResult.Errors[i].AttemptedValue);
        }
        return PagedResult<T>.ValidationError(value, errors);
    }

    /// <summary>
    /// Converts a ValidationResult into a PagedResult object of type T and paging information.
    /// </summary>
    /// <typeparam name="T">The type of the value to include in the PagedResult.</typeparam>
    /// <param name="validationResult">The ValidationResult object to convert.</param>
    /// <param name="pagedInfo">The paging information to include in the PagedResult.</param>
    /// <returns>A PagedResult object of type T indicating success with a value, paging information, and message if the ValidationResult is valid, or containing errors if not.</returns>
    public static PagedResult<T> ToResult<T>(this ValidationResult validationResult, PagedInfo pagedInfo)
    {
        if (validationResult.IsValid)
            return PagedResult<T>.Success(default, pagedInfo, string.Empty);

        var errorsCount = validationResult.Errors.Count;
        var errors = new Error[errorsCount];
        for (var i = 0; i < errors.Length; i++)
        {
            errors[i] = new Error(validationResult.Errors[i].ErrorMessage, validationResult.Errors[i].ErrorCode);

            errors[i].AddOrUpdateMetadata("Severity", validationResult.Errors[i].Severity);
            errors[i].AddOrUpdateMetadata("PropertyName", validationResult.Errors[i].PropertyName);
            errors[i].AddOrUpdateMetadata("AttemptedValue", validationResult.Errors[i].AttemptedValue);
        }
        return PagedResult<T>.ValidationError(default, errors);
    }
}