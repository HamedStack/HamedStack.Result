// ReSharper disable UnusedMember.Global

namespace HamedStack.TheResult;

/// <summary>
/// Represents pagination information for a collection of items, including details about the current page,
/// total number of items, and navigation flags.
/// </summary>
public class PagedInfo
{
    /// <summary>
    /// Gets or sets the index of the first item on the current page.
    /// </summary>
    public int FirstItemOnPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a next page.
    /// </summary>
    public bool HasNextPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether there is a previous page.
    /// </summary>
    public bool HasPreviousPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the current page is the first page.
    /// </summary>
    public bool IsFirstPage { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the current page is the last page.
    /// </summary>
    public bool IsLastPage { get; set; }

    /// <summary>
    /// Gets or sets the index of the last item on the current page.
    /// </summary>
    public int LastItemOnPage { get; set; }

    /// <summary>
    /// Gets or sets the total number of pages.
    /// </summary>
    public int PageCount { get; set; }

    /// <summary>
    /// Gets or sets the number of the current page.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Gets or sets the number of items per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Gets or sets the total number of items in the collection.
    /// </summary>
    public int TotalCount { get; set; }
}
