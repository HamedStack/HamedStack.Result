using HamedStack.Functional;
// ReSharper disable GrammarMistakeInComment
// ReSharper disable UnusedMember.Global
// ReSharper disable ConvertClosureToMethodGroup

namespace HamedStack.TheResult.Functional;

/// <summary>
/// Provides extension methods for converting between <see cref="Result{T}"/> and other functional result types.
/// </summary>
public static class ResultExtensions
{
    /// <summary>
    /// Converts an <see cref="Either{TLeft, TRight}"/> instance to a <see cref="Result{T}"/> instance.
    /// </summary>
    /// <typeparam name="TLeft">The type of the Left value in Either.</typeparam>
    /// <typeparam name="TRight">The type of the Right value in Either.</typeparam>
    /// <param name="either">The Either instance to convert.</param>
    /// <returns>A <see cref="Result{T}"/> instance representing success if Either was Right, or failure if it was Left.</returns>
    public static Result<TRight> ToResult<TLeft, TRight>(this Either<TLeft, TRight> either)
    {
        return either.Match(
            left => Result<TRight>.Failure($"Error: {left}"),
            right => Result<TRight>.Success(right)
        );
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to an <see cref="Either{TLeft, TRight}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the successful value in Result.</typeparam>
    /// <param name="result">The Result instance to convert.</param>
    /// <returns>An Either instance where Left is a string for errors, and Right contains the value.</returns>
    public static Either<string, T> ToEither<T>(this Result<T> result)
    {
        return result.IsSuccess
            ? Either<string, T>.Right(result.Value!)
            : Either<string, T>.Left(string.Join(", ", result.Errors.Select(e => e.Message)));
    }

    /// <summary>
    /// Converts an <see cref="Option{T}"/> instance to a <see cref="Result{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Option.</typeparam>
    /// <param name="option">The Option instance to convert.</param>
    /// <param name="noneMessage">The message to use if the Option is None.</param>
    /// <returns>A Result instance representing success if Option was Some, or failure if it was None.</returns>
    public static Result<T> ToResult<T>(this Option<T> option, string noneMessage = "Option has no value.")
    {
        return option.Match(
            some => Result<T>.Success(some),
            () => Result<T>.Failure(noneMessage)
        );
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to an <see cref="Option{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Result.</typeparam>
    /// <param name="result">The Result instance to convert.</param>
    /// <returns>An Option instance representing Some if the Result is successful, otherwise None.</returns>
    public static Option<T> ToOption<T>(this Result<T> result)
    {
        return result.IsSuccess ? Option<T>.Some(result.Value!) : Option<T>.None;
    }

    /// <summary>
    /// Converts an <see cref="Exceptional{T}"/> instance to a <see cref="Result{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Exceptional.</typeparam>
    /// <param name="exceptional">The Exceptional instance to convert.</param>
    /// <returns>A Result instance representing success if Exceptional was successful, or failure if it was not.</returns>
    public static Result<T> ToResult<T>(this Exceptional<T> exceptional)
    {
        return exceptional.Match(
            success => Result<T>.Success(success),
            failure => Result<T>.Failure(failure.Message)
        );
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to an <see cref="Exceptional{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Result.</typeparam>
    /// <param name="result">The Result instance to convert.</param>
    /// <returns>An Exceptional instance representing success if Result was successful, otherwise failure.</returns>
    public static Exceptional<T> ToExceptional<T>(this Result<T> result)
    {
        return result.IsSuccess ? Exceptional<T>.Success(result.Value!) : Exceptional<T>.Failure(new Exception(string.Join(", ", result.Errors.Select(e => e.Message))));
    }

    /// <summary>
    /// Converts a <see cref="Validation{T}"/> instance to a <see cref="Result{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Validation.</typeparam>
    /// <param name="validation">The Validation instance to convert.</param>
    /// <returns>A Result instance representing success if Validation was successful, otherwise failure.</returns>
    public static Result<T> ToResult<T>(this Validation<T> validation)
    {
        return validation.Match(
            success => Result<T>.Success(success),
            errors => Result<T>.Failure(errors.ToArray())
        );
    }

    /// <summary>
    /// Converts a <see cref="Result{T}"/> instance to a <see cref="Validation{T}"/> instance.
    /// </summary>
    /// <typeparam name="T">The type of the value in Result.</typeparam>
    /// <param name="result">The Result instance to convert.</param>
    /// <returns>A Validation instance representing success if the Result was successful, otherwise failure.</returns>
    public static Validation<T> ToValidation<T>(this Result<T> result)
    {
        return result.IsSuccess ? Validation<T>.Success(result.Value!) : Validation<T>.Failure(result.Errors.Select(e => e.Message).ToArray());
    }
}
