// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedType.Global
// ReSharper disable UnusedMember.Global

namespace HamedStack.TheResult;


public static class ResultExtensions
{
    public static Result<T> AsResult<T>(this Result result, T? value = default)
    {
        return result.Status switch
        {
            ResultStatus.Success => Result<T>.Success(value, result.SuccessMessage),
            ResultStatus.Failure => Result<T>.Failure(value, result.Errors),
            ResultStatus.Forbidden => Result<T>.Forbidden(value, result.Errors),
            ResultStatus.Unauthorized => Result<T>.Unauthorized(value, result.Errors),
            ResultStatus.Invalid => Result<T>.Invalid(value, result.Errors),
            ResultStatus.NotFound => Result<T>.NotFound(value, result.Errors),
            ResultStatus.Conflict => Result<T>.Conflict(value, result.Errors),
            ResultStatus.Unavailable => Result<T>.Unavailable(value, result.Errors),
            ResultStatus.Unsupported => Result<T>.Unsupported(value, result.Errors),
            ResultStatus.ValidationError => Result<T>.ValidationError(value, result.Errors),
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    public static string[] GetErrorMessages(this Result result)
    {
        return result.Errors.Select(e => e.Message).ToArray();
    }
    public static Result Finally(this Result result, Action<Result> action)
    {
        action(result);
        return result;
    }

    public static Result Flatten(this Result<Result> result)
    {
        return result.IsSuccess
            ? Result.Success()
            : Result.Failure(result.Errors);
    }

    public static Result IfFailure(this Result result, Action<Result> action)
    {
        if (!result.IsSuccess) action(result);
        return result;
    }

    public static Result IfSuccess(this Result result, Action<Result> action)
    {
        if (result.IsSuccess) action(result);
        return result;
    }

    public static Result IfSuccess(this Result result, Action action)
    {
        if (result.IsSuccess) action();
        return result;
    }
    public static Result IfFailure(this Result result, Action action)
    {
        if (!result.IsSuccess) action();
        return result;
    }
    public static Result Join(this IEnumerable<Result> results, string separator = ", ")
    {
        var failures = results.Where(r => !r.IsSuccess).ToList();
        if (!failures.Any()) return Result.Success();

        var combinedMessage = string.Join(separator, failures.SelectMany(f => f.Errors).Select(e => e.Message));
        return Result.Failure(combinedMessage);
    }
}