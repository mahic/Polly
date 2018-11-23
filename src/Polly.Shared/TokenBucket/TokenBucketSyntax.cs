using Polly.Timeout;
using Polly.Utilities;
using System;
using System.Threading.Tasks;
using Polly.TokenBucket;

namespace Polly
{
    public partial class Policy
    {
        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy TokenBucket(double bucketSize, double bucketFillRate)
        {
            TokenBucketValidator.ValidateSecondsTimeout(bucketSize, bucketFillRate);
            Action<Context, Task, Exception> doNothing = (_, ___, ____) => { };

            return TokenBucket(ctx => Tuple.Create(bucketSize, bucketFillRate), TokenBucketStrategy.Optimistic, doNothing);
        }

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        //public static TokenBucketPolicy TokenBucket(int seconds, TimeoutStrategy timeoutStrategy)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);
        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

        //    return TokenBucket(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(int seconds, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);

        //    return TokenBucket(ctx => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

        //    return TokenBucket(ctx => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);

        //    return TokenBucket(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

        //    return TokenBucket(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);
        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

        //    return TokenBucket(ctx => timeout, TimeoutStrategy.Optimistic, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);
        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

        //    return TokenBucket(ctx => timeout, timeoutStrategy, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    return TokenBucket(ctx => timeout, TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    return TokenBucket(ctx => timeout, TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    return TokenBucket(ctx => timeout, timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    return TokenBucket(ctx => timeout, timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
        //    return TokenBucket(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
        //    return TokenBucket(ctx => timeoutProvider(), timeoutStrategy, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucket(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucket(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucket(ctx => timeoutProvider(), timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucket(ctx => timeoutProvider(), timeoutStrategy, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy TokenBucket(Func<Context, TimeSpan> timeoutProvider)
        //{
        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
        //    return TokenBucket(timeoutProvider, TimeoutStrategy.Optimistic, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        //public static TokenBucketPolicy TokenBucket(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
        //{
        //    Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
        //    return TokenBucket(timeoutProvider, timeoutStrategy, doNothing);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    return TokenBucket(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
        //{
        //    return TokenBucket(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="timeoutStrategy">The timeout strategy.</param>
        ///// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeout</exception>
        //public static TokenBucketPolicy TokenBucket(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
        //{
        //    if (onTimeout == null) throw new ArgumentNullException(nameof(onTimeout));

        //    return TokenBucket(timeoutProvider, timeoutStrategy, (ctx, timeout, task, ex) => onTimeout(ctx, timeout, task));
        //}

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy TokenBucket(Func<Context, Tuple<double, double>> timeoutProvider, TokenBucketStrategy timeoutStrategy, Action<Context, Task, Exception> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));
            if (onTimeout == null) throw new ArgumentNullException(nameof(onTimeout));

            Tuple<double, double> config = timeoutProvider(Context.None);
            var state = new TokenBucketState(config.Item1, config.Item2, Environment.TickCount);
            return new TokenBucketPolicy(
                (action, context, cancellationToken) => TokenBucketEngine.Implementation(
                    (ctx, ct) => { action(ctx, ct); return EmptyStruct.Instance; },
                    context,
                    cancellationToken,
                    timeoutProvider,
                    timeoutStrategy,
                    onTimeout)
                );
        }
    }
}