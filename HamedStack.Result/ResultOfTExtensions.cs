namespace HamedStack.TheResult;

public static class ResultTExtensions
{
    public static Result<IEnumerable<T>> Aggregate<T>(this IEnumerable<Result<T>> results)
    {
        var resultArray = results.ToArray();
        foreach (var result in resultArray)
            if (!result.IsSuccess)
                return Result<IEnumerable<T>>.Error(null, result.ErrorMessages);

        var output = resultArray.Select(r => r.Value);
        return Result<IEnumerable<T>>.Success(output!);
    }

    public static Result<TResult> Bind<T, TResult>(this Result<T> result, Func<T?, Result<TResult>> func)
    {
        return (Result<TResult>)(result.IsSuccess
            ? func(result.Value)
            : Result.Error(result.ErrorMessages));
    }

    public static Result Combine(this IEnumerable<Result> results, string separator = ", ")
    {
        var failures = results.Where(r => !r.IsSuccess).ToList();
        if (!failures.Any()) return Result.Success();

        var combinedMessage = string.Join(separator, failures.SelectMany(f => f.ErrorMessages));
        return Result.Error(combinedMessage);
    }
    public static Result<T> Ensure<T>(this Result<T> result, Func<T?, bool> predicate, string errorMessage)
    {
        if (!result.IsSuccess) return result;
        return (Result<T>)(!predicate(result.Value) ? Result.Error(errorMessage) : result);
    }

    public static Result<T> Finally<T>(this Result<T> result, Action<Result<T>> action)
    {
        action(result);
        return result;
    }

    public static Result<T> Flatten<T>(this Result<Result<T>> result)
    {
        return (Result<T>)(result.IsSuccess
            ? result.Value!
            : Result.Error(result.ErrorMessages));
    }

    public static Result<T> IfFailure<T>(this Result<T> result, Action<Result<T>> action)
    {
        if (!result.IsSuccess) action(result);
        return result;
    }

    public static Result<T> IfFailure<T>(this Result<T> result, Action action)
    {
        if (!result.IsSuccess) action();
        return result;
    }

    public static Result<T> IfSuccess<T>(this Result<T> result, Action<Result<T>> action)
    {
        if (result.IsSuccess) action(result);
        return result;
    }

    public static Result<T> IfSuccess<T>(this Result<T> result, Action action)
    {
        if (result.IsSuccess) action();
        return result;
    }

    public static Result<TResult> Map<T, TResult>(this Result<T> result, Func<T?, TResult> mapper)
    {
        return (Result<TResult>)(result.IsSuccess
            ? Result<TResult>.Success(mapper(result.Value))
            : Result.Error(result.ErrorMessages));
    }

    public static Result<T> MapError<T>(this Result<T> result, params string[] errorMessages)
    {
        return (Result<T>)(!result.IsSuccess
            ? Result.Error(errorMessages)
            : result);
    }

    public static TResult Match<T, TResult>(this Result<T> result, Func<T?, TResult> success,
        Func<string[], TResult> failure)
    {
        return result.IsSuccess
            ? success(result.Value)
            : failure(result.ErrorMessages);
    }

    public static T? OrElse<T>(this Result<T> result, T? defaultValue = default)
    {
        return result.IsSuccess ? result.Value! : defaultValue;
    }

    public static Result<T> Tap<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess) action(result.Value!);
        return result;
    }
    public static Result<T> TapError<T>(this Result<T> result, Action<T> action)
    {
        if (!result.IsSuccess) action(result.Value!);
        return result;
    }
    public static Result<T> Then<T>(this Result<T> result, Action<T> action)
    {
        if (result.IsSuccess) action(result.Value!);
        return result;
    }

    public static Result<T> Unwrap<T>(this Result<T?> result)
    {
        return result.IsSuccess ? Result<T>.Success(result.Value!) : Result<T>.Error(result.Value, result.ErrorMessages);
    }

    public static T? UnwrapOr<T>(this Result<T> result, T? defaultValue)
    {
        return result.IsSuccess ? result.Value : defaultValue;
    }

    public static Result<T> WithValue<T>(this Result<T> result, T newValue)
    {
        return result.IsSuccess ? Result<T>.Success(newValue) : result;
    }
}
