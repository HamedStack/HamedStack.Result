using Microsoft.AspNetCore.Mvc;

namespace HamedStack.TheResult.AspNetCore;

/// <summary>
/// Represents an action result wrapper for a non-generic <see cref="Result"/> object.
/// </summary>
public class ResultAction : ActionResult
{
    /// <summary>
    /// Gets or sets the <see cref="Result"/> object associated with this action.
    /// </summary>
    public Result Result { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ResultAction"/> class with the specified <see cref="Result"/>.
    /// </summary>
    /// <param name="result">The result object to be wrapped by this action result.</param>
    public ResultAction(Result result)
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
