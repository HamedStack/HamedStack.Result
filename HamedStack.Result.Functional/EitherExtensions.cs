using HamedStack.Functional;

namespace HamedStack.TheResult.Functional;

public static class EitherExtensions
{
    public static Either<Unit, T> ToEither<T>(this Result<T> result) where T : new()
    {
        return result.IsSuccess
            ? Either<Unit, T>.CreateRight(result.Value ?? new T())
            : Either<Unit, T>.CreateLeft(Unit.Value);
    }
}