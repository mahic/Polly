using System;
#if !PORTABLE
using System.Runtime.Serialization;
#endif

namespace Polly.TokenBucket
{
    /// <summary>
    /// Exception thrown when a delegate executed through a <see cref="TimeoutPolicy"/> does not complete, before the configured timeout.
    /// </summary>
#if !PORTABLE
    [Serializable]
#endif
    public class TokenBucketRejectedException : ExecutionRejectedException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutRejectedException" /> class.
        /// </summary>
        public TokenBucketRejectedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutRejectedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public TokenBucketRejectedException(String message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutRejectedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public TokenBucketRejectedException(String message, Exception innerException) : base(message, innerException)
        {
        }

#if !PORTABLE
        /// <summary>
        /// Initializes a new instance of the <see cref="TimeoutRejectedException"/> class.
        /// </summary>
        /// <param name="info">The information.</param>
        /// <param name="context">The context.</param>
        protected TimeoutRejectedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
#endif
    }
}
