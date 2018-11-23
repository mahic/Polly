﻿using System;
using System.Threading.Tasks;
using Polly.Timeout;
using Polly.TokenBucket;
using Polly.Utilities;

namespace Polly
{
    public partial class Policy
    {
        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy TokenBucketAsync(int seconds)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        public static TokenBucketPolicy TokenBucketAsync(int seconds, TimeoutStrategy timeoutStrategy)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(int seconds, Func<Context
            , TimeSpan, Task, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">seconds;Value must be greater than zero.</exception>
        public static TokenBucketPolicy TokenBucketAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">seconds;Value must be greater than zero.</exception>
        public static TokenBucketPolicy TokenBucketAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            return TokenBucketAsync(ctx => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(ctx => timeout, TimeoutStrategy.Optimistic, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(ctx => timeout, timeoutStrategy, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);

            return TokenBucketAsync(ctx => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);

            return TokenBucketAsync(ctx => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);

            return TokenBucketAsync(ctx => timeout, timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);

            return TokenBucketAsync(ctx => timeout, timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;
            return TokenBucketAsync(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;
            return TokenBucketAsync(ctx => timeoutProvider(), timeoutStrategy, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucketAsync(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucketAsync(ctx => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucketAsync(ctx => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucketAsync(ctx => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider)
        {
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(timeoutProvider, TimeoutStrategy.Optimistic, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
        {
            Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => TaskHelper.EmptyTask;

            return TokenBucketAsync(timeoutProvider, timeoutStrategy, doNothingAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            return TokenBucketAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            return TokenBucketAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        {
            if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

            return TokenBucketAsync(timeoutProvider, timeoutStrategy, (ctx, timeout, task, ex) => onTokenBucketAsync(ctx, timeout, task));
        }

        /// <summary>
        /// Builds a <see cref="Policy" /> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="timeoutStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy TokenBucketAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy
            , Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));
            if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

            return new TokenBucketPolicy(
                (action, context, cancellationToken, continueOnCapturedContext) => TimeoutEngine.ImplementationAsync(
                    async (ctx, ct) => { await action(ctx, ct).ConfigureAwait(continueOnCapturedContext); return EmptyStruct.Instance; },
                    context,
                    timeoutProvider,
                    timeoutStrategy,
                    onTimeoutAsync,
                    cancellationToken,
                    continueOnCapturedContext)
                );
        }
    }
}
