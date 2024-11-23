// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Provides extension methods for ModelStateDictionary to transform it into Result or IActionResult.
/// </summary>
public static class ResultModelStateExtensions
{
    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance.
    /// </summary>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>A <see cref="Result"/> instance that represents the validation outcome.</returns>
    public static Result ToResult(this ModelStateDictionary modelState)
    {
        var errors = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        var errorMessage = string.Join(" ", errors);
        var result = Result.ValidationError(errorMessage);


        return result;
    }

    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance into an <see cref="IActionResult"/>.
    /// </summary>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>An <see cref="IActionResult"/> instance that represents the validation outcome.</returns>
    public static IActionResult ToActionResult(this ModelStateDictionary modelState)
    {
        return modelState.ToResult().ToActionResult();
    }
}