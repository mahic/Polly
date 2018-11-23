namespace Polly.TokenBucket
{
    /// <summary>
    /// Defines properties and methods common to all Timeout policies.
    /// </summary>

    public interface ITokenBucketPolicy : IsPolicy
    {
    }

    /// <summary>
    /// Defines properties and methods common to all Timeout policies generic-typed for executions returning results of type <typeparamref name="TResult"/>.
    /// </summary>
    public interface ITokenBucketPolicy<TResult> : ITokenBucketPolicy
    {

    }
}
