using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Polly.TokenBucket;

namespace Polly.TokenBucket
{
    public partial class TokenBucketPolicy : ITokenBucketPolicy
    {
        internal TokenBucketPolicy(Func<Func<Context, CancellationToken, Task>, Context, CancellationToken, bool, Task> asyncExceptionPolicy)
           : base(asyncExceptionPolicy, Enumerable.Empty<ExceptionPredicate>())
        {
        }

    }

    public partial class TokenBucketPolicy<TResult> : TokenBucketPolicy<TResult>
    {
        internal TokenBucketPolicy(
            Func<Func<Context, CancellationToken, Task<TResult>>, Context, CancellationToken, bool, Task<TResult>> asyncExecutionPolicy
            ) : base(asyncExecutionPolicy, Enumerable.Empty<ExceptionPredicate>(), Enumerable.Empty<ResultPredicate<TResult>>())
        {
        }
    }
}