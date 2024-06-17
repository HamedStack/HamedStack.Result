
using HamedStack.Paging;

namespace HamedStack.TheResult.Paging;

/// <summary>
/// Provides extension methods for handling paginated lists, allowing for easy conversion
/// to a paged result format.
/// </summary>
public static class PagingExtensions
{
    /// <summary>
    /// Converts a <see cref="PagedList{T}"/> to a <see cref="PagedResult{T}"/>, encapsulating the paginated list
    /// with additional metadata and an optional success message.
    /// </summary>
    /// <typeparam name="T">The type of the items within the paginated list.</typeparam>
    /// <param name="result">The paginated list to convert.</param>
    /// <param name="successMessage">An optional message indicating success. Default is an empty string.</param>
    /// <returns>
    /// A <see cref="PagedResult{T}"/> object containing the items from the original paginated list, 
    /// along with pagination metadata and an optional success message.
    /// </returns>
    /// <remarks>
    /// This extension method is useful for scenarios where a paginated list needs to be returned from an API call,
    /// including metadata such as page number, page size, and total item count for frontend pagination controls.
    /// </remarks>
    public static PagedResult<IList<T>> ToPagedResult<T>(this PagedList<T> result, string successMessage = "")
    {
        return PagedResult<IList<T>>.Success(result.Items, new PagedInfo
        {
            FirstItemOnPage = result.FirstItemOnPage,
            HasNextPage = result.HasNextPage,
            HasPreviousPage = result.HasPreviousPage,
            IsFirstPage = result.IsFirstPage,
            IsLastPage = result.IsLastPage,
            LastItemOnPage = result.LastItemOnPage,
            PageCount = result.PageCount,
            PageNumber = result.PageNumber,
            PageSize = result.PageSize,
            TotalCount = result.TotalCount,
        }, successMessage);
    }
}