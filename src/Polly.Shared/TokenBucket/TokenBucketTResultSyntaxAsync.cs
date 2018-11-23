using System;
using System.Threading.Tasks;
using Polly.TokenBucket;

namespace Polly
{
    public partial class Policy
    {
        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="seconds">The number of seconds after which to timeout.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        /// <returns>The policy instance.</returns>
        public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(double bucketSize, double bucketFillRate)
        {
            TokenBucketValidator.ValidateSecondsTimeout(bucketSize, bucketFillRate);

            Func<Context, Task, Exception, Task> doNothingAsync = (_, ___, ____) => Task.FromResult(default(TResult));
            return TokenBucketAsync<TResult>(ctx => Tuple.Create(bucketSize, bucketFillRate), TokenBucketStrategy.Optimistic, doNothingAsync);
        }

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);

        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);

        //    return TokenBucketAsync<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

        //    return TokenBucketAsync<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    TokenBucketValidator.ValidateSecondsTimeout(seconds);

        //    return TokenBucketAsync<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="seconds">The number of seconds after which to timeout.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">seconds;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(int seconds, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (seconds <= 0) throw new ArgumentOutOfRangeException(nameof(seconds));

        //    return TokenBucketAsync<TResult>(ctx => TimeSpan.FromSeconds(seconds), TokenBucketStrategy, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);
        //    if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (timeout <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(timeout));
        //    if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    TokenBucketValidator.ValidateTimeSpanTimeout(timeout);

        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeout">The timeout.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentOutOfRangeException">timeout;Value must be greater than zero.</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(TimeSpan timeout, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (timeout <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(timeout));

        //    return TokenBucketAsync<TResult>(ctx => timeout, TokenBucketStrategy, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), TokenBucketStrategy, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));

        //    return TokenBucketAsync<TResult>(ctx => timeoutProvider(), TokenBucketStrategy, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, TimeSpan> timeoutProvider)
        //{
        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <returns>The policy instance.</returns>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy)
        //{
        //    Func<Context, TimeSpan, Task, Exception, Task> doNothingAsync = (_, __, ___, ____) => Task.FromResult(default(TResult));
        //    return TokenBucketAsync<TResult>(timeoutProvider, TokenBucketStrategy, doNothingAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    return TokenBucketAsync<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
        //{
        //    return TokenBucketAsync<TResult>(timeoutProvider, TokenBucketStrategy.Optimistic, onTimeoutAsync);
        //}

        ///// <summary>
        ///// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        ///// </summary>
        ///// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        ///// <param name="TokenBucketStrategy">The timeout strategy.</param>
        ///// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, and a <see cref="Task"/> capturing the abandoned, timed-out action. 
        ///// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        ///// <returns>The policy instance.</returns>
        ///// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        ///// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        //public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
        //{
        //    if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

        //    return TokenBucketAsync<TResult>(timeoutProvider, TokenBucketStrategy, (ctx, timeout, task, ex) => onTimeoutAsync(ctx, timeout, task));
        //}

        /// <summary>
        /// Builds a <see cref="Policy{TResult}"/> that will wait asynchronously for a delegate to complete for a specified period of time. A <see cref="TimeoutRejectedException"/> will be thrown if the delegate does not complete within the configured timeout.
        /// </summary>
        /// <param name="timeoutProvider">A function to provide the timeout for this execution.</param>
        /// <param name="TokenBucketStrategy">The timeout strategy.</param>
        /// <param name="onTimeoutAsync">An action to call on timeout, passing the execution context, the timeout applied, the <see cref="Task"/> capturing the abandoned, timed-out action, and the captured <see cref="Exception"/>.
        /// <remarks>The Task parameter will be null if the executed action responded co-operatively to cancellation before the policy timed it out.</remarks></param>
        /// <returns>The policy instance.</returns>
        /// <exception cref="System.ArgumentNullException">timeoutProvider</exception>
        /// <exception cref="System.ArgumentNullException">onTimeoutAsync</exception>
        public static TokenBucketPolicy<TResult> TokenBucketAsync<TResult>(Func<Context, Tuple<double, double>> timeoutProvider, TokenBucketStrategy TokenBucketStrategy, Func<Context, Task, Exception, Task> onTimeoutAsync)
        {
            if (timeoutProvider == null) throw new ArgumentNullException(nameof(timeoutProvider));
            if (onTimeoutAsync == null) throw new ArgumentNullException(nameof(onTimeoutAsync));

            return new TokenBucketPolicy<TResult>(
                (action, context, cancellationToken, continueOnCapturedContext) => TokenBucketEngine.ImplementationAsync(
                    action,
                    context,
                    timeoutProvider,
                    TokenBucketStrategy,
                    onTimeoutAsync,
                    cancellationToken,
                    continueOnCapturedContext)
                );
        }
    }
}
