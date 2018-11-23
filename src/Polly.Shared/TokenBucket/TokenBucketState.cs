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
            var ticksNow = currentTicks;
            var delta = ticksNow - LastCalledTicks;
            var tokenCountIncrease = (delta / 1000) * _bucketFillRate;
            var tempBucketCount = Math.Max(BucketTokenCount + tokenCountIncrease, _bucketSize);
            var newBucketCount = tempBucketCount - size;
            BucketTokenCount = newBucketCount;
            LastCalledTicks = ticksNow;
        }
    }
}
