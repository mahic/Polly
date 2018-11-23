using System;
using Polly.Timeout;
using System.Threading.Tasks;
using Polly.TokenBucket;

namespace Polly
{
    public partial class Policy
    {
        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy.Optimistic, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds, Action<Context, TimeSpan, Task> onTimeout)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);
            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));
            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task> onTimeout)
        {
            TimeoutValidator.ValidateSecondsTimeout(seconds);

            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

            return TokenBucket<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };

            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task> onTimeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeout">The timeout.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            TimeoutValidator.ValidateTimeSpanTimeout(timeout);
            return TokenBucket<TResult>(ctx => timeout, TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

            return TokenBucket<TResult>(ctx => timeoutProvider(), TokenBucketStrategy, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider)
        {
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
            return TokenBucket<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy)
        {
            Action<Context, TimeSpan, Task, Exception> doNothing = (_, __, ___, ____) => { };
            return TokenBucket<TResult>(timeoutProvider, TokenBucketStrategy, doNothing);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}"/> capturing the abandoned, timed-out action. 
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
        {
            return TokenBucket<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            return TokenBucket<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, onTimeout);
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task{TResult}" /> capturing the abandoned, timed-out action.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task> onTimeout)
        {
            if (onTimeout == null) throw new ArgumentNullException(nameof(onTimeout));

            return TokenBucket<TResult>(timeoutProvider, TokenBucketStrategy, (ctx, timeout, task, ex) => onTimeout(ctx, timeout, task));
        }

        /// <summary>
        /// Builds a <see cref="Policy{TResult}" /> that will wait for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException" /> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <typeparam name="TResult">The return type of delegates which may be executed through the policy.</typeparam>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeout">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task{TResult}" /> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeout</exception>
        public static TokenBucketPolicy<TResult> TokenBucket<TResult>(Func<Context, TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));
            if (onTimeout == null) throw new ArgumentNullException(nameof(onTimeout));

            return new TokenBucketPolicy<TResult>(
                (action, context, cancellationToken) => TokenBucketEngine.Implementation<TResult>(
                    action,
                    context,
                    cancellationToken,
                    timeoutProvider,
                    TokenBucketStrategy,
                    onTimeout)
                );
        }
    }
}