namespace HamedStack.Result;

public static class PagedResultExtensions
{
    /// <summary>
    /// Converts a <see cref="Result{T}"/> to a <see cref="PagedResult{T}"/> with additional pagination information.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in the result.</typeparam>
    /// <param name="result">The result to convert.</param>
    /// <param name="pagedInfo">The pagination information to include in the new paged result.</param>
    /// <returns>A <see cref="PagedResult{T}"/> that contains the value and success message from the original result, as well as the provided pagination information.</returns>
    public static PagedResult<T> ToPagedResult<T>(this Result<T> result, PagedInfo pagedInfo)
    {
        return PagedResult<T>.Success(result.Value, pagedInfo, result.SuccessMessage);
    }
}