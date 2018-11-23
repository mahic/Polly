using System;
using System.Runtime.ExceptionServices;
using System.Threading;
using System.Threading.Tasks;
using Polly.Utilities;

namespace Polly.TokenBucket
{
    internal static partial class TokenBucketEngine
    {
        internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action,
            Context context,
            CancellationToken cancellationToken,
            Func<Context, Tuple<double, double>> tokenBucketProvider,
            TokenBucketStrategy timeoutStrategy,
            Action<Context, Task, Exception> onThrottle)
        {
            cancellationToken.ThrowIfCancellationRequested();
            var timeout = tokenBucketProvider(context);

            using (CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource())
            {
                using (CancellationTokenSource combinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationTokenSource.Token))
                {
                    CancellationToken combinedToken = combinedTokenSource.Token;

                    Task<TResult> actionTask = null;
                    try
                    {
                        if (timeoutStrategy == TokenBucketStrategy.Optimistic)
                        {
                            //SystemClock.CancelTokenAfter(timeoutCancellationTokenSource, timeout);
                            return action(context, combinedToken);
                        }

                        // else: timeoutStrategy == TimeoutStrategy.Pessimistic

                        //SystemClock.CancelTokenAfter(timeoutCancellationTokenSource, timeout);

                        actionTask = Task.Run(() =>
                            action(context, combinedToken)       // cancellation token here allows the user delegate to react to cancellation: possibly clear up; then throw an OperationCanceledException.
                            , combinedToken);           // cancellation token here only allows Task.Run() to not begin the passed delegate at all, if cancellation occurs prior to invoking the delegate.  
                        try
                        {
                            actionTask.Wait(timeoutCancellationTokenSource.Token); // cancellation token here cancels the Wait() and causes it to throw, but does not cancel actionTask.  We use only timeoutCancellationTokenSource.Token here, not combinedToken.  If we allowed the user's cancellation token to cancel the Wait(), in this pessimistic scenario where the user delegate may not observe that cancellation, that would create a no-longer-observed task.  That task could in turn later fault before completing, risking an UnobservedTaskException.
                        }
                        catch (AggregateException ex) when (ex.InnerExceptions.Count == 1) // Issue #270.  Unwrap extra AggregateException caused by the way pessimistic timeout policy for synchronous executions is necessarily constructed.
                        {
                            ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
                        }

                        return actionTask.Result;
                    }
                    catch (Exception ex)
                    {
                        if (timeoutCancellationTokenSource.IsCancellationRequested)
                        {
                            onThrottle(context, actionTask, ex);
                            throw new TokenBucketRejectedException("The delegate executed through TimeoutPolicy did not complete within the timeout.", ex);
                        }

                        throw;
                    }
                }
            }
        }

    }
}