using HamedStack.Functional;

namespace HamedStack.TheResult.Functional;

public static class MaybeExtensions
{
    public static Maybe<T> ToMaybe<T>(this Result<T> result) where T : new()
    {
        return result.IsSuccess
            ? Maybe<T>.Just(result.Value ?? new T())
            : Maybe<T>.Nothing();
    }
}