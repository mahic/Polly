using System;

namespace Polly.TokenBucket
{
    internal class TokenBucketState
    {
        private readonly double _bucketSize;
        private readonly double _bucketFillRate;
        internal TokenBucketState(double bucketSize, double bucketFillRate, int currentTicks)
        {
            _bucketSize = bucketSize;
            _bucketFillRate = bucketFillRate;
            BucketTokenCount = bucketSize;
            LastCalledTicks = currentTicks;
        }

        internal double BucketTokenCount { get; private set; }
        internal long LastCalledTicks { get; private set; }

        public void UpdateTokenCount(int currentTicks, double size)
        {
            if (size > _bucketSize)
                throw new ArgumentOutOfRangeException("size", "The requested size is greater than the bucket size");
            var ticksNow = currentTicks;
            var delta = ticksNow - LastCalledTicks;
            var tokenCountIncrease = (delta / 1000.0) * _bucketFillRate;
            var tempBucketCount = Math.Min(BucketTokenCount + tokenCountIncrease, _bucketSize);
            var newBucketCount = tempBucketCount - size;
            if (newBucketCount < 0.0)
                throw new TokenBucketRejectedException("The bucket does not have enough tokens for the request");
            BucketTokenCount = newBucketCount;
            LastCalledTicks = ticksNow;
        }
    }
}
