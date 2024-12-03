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

        var result = Result.ValidationError(errors.ToArray());


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

    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance into a <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result's value.</typeparam>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>A <see cref="Result{T}"/> instance representing the validation outcome.</returns>
    public static Result<T> ToResult<T>(this ModelStateDictionary modelState)
    {
        var errors = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        return Result<T>.ValidationError(default, errors.ToArray());
    }

    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance into a <see cref="PagedResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items in the paged result.</typeparam>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>A <see cref="PagedResult{T}"/> instance representing the validation outcome.</returns>
    public static PagedResult<T> ToPagedResult<T>(this ModelStateDictionary modelState)
    {
        var errors = modelState.Values
            .SelectMany(v => v.Errors)
            .Select(e => e.ErrorMessage)
            .ToList();

        return PagedResult<T>.ValidationError(default, errors.ToArray());
    }

    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance into an <see cref="IActionResult"/> for <see cref="Result{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the result's value.</typeparam>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>An <see cref="IActionResult"/> representing the validation outcome.</returns>
    public static IActionResult ToActionResult<T>(this ModelStateDictionary modelState)
    {
        return modelState.ToResult<T>().ToActionResult();
    }

    /// <summary>
    /// Transforms a <see cref="ModelStateDictionary"/> instance into an <see cref="IActionResult"/> for <see cref="PagedResult{T}"/>.
    /// </summary>
    /// <typeparam name="T">The type of the items in the paged result.</typeparam>
    /// <param name="modelState">The ModelStateDictionary instance.</param>
    /// <returns>An <see cref="IActionResult"/> representing the validation outcome.</returns>
    public static IActionResult ToPagedActionResult<T>(this ModelStateDictionary modelState)
    {
        return modelState.ToPagedResult<T>().ToActionResult();
    }
}