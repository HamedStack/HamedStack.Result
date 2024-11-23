using Microsoft.AspNetCore.Mvc;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Represents an action result wrapper for a generic <see cref="Result{T}"/> object.
/// </summary>
/// <typeparam name="T">The type of the data contained in the result.</typeparam>
public class ResultAction<T> : ActionResult
{
    /// <summary>
    /// Gets or sets the <see cref="Result{T}"/> object associated with this action.
    /// </summary>
    public Result<T> Result { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResultAction{T}"/> class with the specified <see cref="Result{T}"/>.
    /// </summary>
    /// <param name="result">The result object to be wrapped by this action result.</param>
    public ResultAction(Result<T> result)
    {
        Result = result;
    }

    /// <summary>
    /// Executes the action result asynchronously.
    /// </summary>
    /// <param name="context">The context in which the result is executed.</param>
    /// <returns>A task that represents the asynchronous operation.</returns>
    public override async Task ExecuteResultAsync(ActionContext context)
    {
        var actionResult = Result.ToActionResult();
        await actionResult.ExecuteResultAsync(context);
    }
}