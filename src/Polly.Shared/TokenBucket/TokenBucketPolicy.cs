using System;
using System.Threading;
using Polly.Utilities;

namespace Polly.TokenBucket
{
    /// <summary>
    /// A timeout policy which can be applied to delegates.
    /// </summary>
    public partial class TokenBucketPolicy : Policy, ITokenBucketPolicy
    {
        internal TokenBucketPolicy(
            Action<Action<Context, CancellationToken>, Context, CancellationToken> exceptionPolicy
            ) 
            : base(exceptionPolicy, PredicateHelper.EmptyExceptionPredicates)
        {

        }
    }

    /// <summary>
    /// A timeout policy which can be applied to delegates returning a value of type <typeparamref name="TResult"/>.
    /// </summary>
    public partial class TokenBucketPolicy<TResult> : Policy<TResult>, ITokenBucketPolicy<TResult>
    {
        internal TokenBucketPolicy(
            Func<Func<Context, CancellationToken, TResult>, Context, CancellationToken, TResult> executionPolicy
            ) : base(executionPolicy, PredicateHelper.EmptyExceptionPredicates, PredicateHelper<TResult>.EmptyResultPredicates)
        {
        }
    }
}