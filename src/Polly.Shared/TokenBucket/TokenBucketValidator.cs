using System;

namespace Polly.TokenBucket
{
    internal static class TokenBucketValidator
    {
        internal static void ValidateSecondsTimeout(double bucketSize, double bucketFillRate)
        {
            if (bucketSize <= 0) throw new ArgumentOutOfRangeException(nameof(bucketSize));
            if (bucketFillRate <= 0) throw new ArgumentOutOfRangeException(nameof(bucketSize));
        }
    }
}
