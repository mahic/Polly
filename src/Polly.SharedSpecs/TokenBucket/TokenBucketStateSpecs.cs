using System;
using FluentAssertions;
using Polly.TokenBucket;
using Xunit;

namespace Polly.SharedSpecs.TokenBucket
{
    public class TokenBucketStateSpecs
    {
        [Fact]
        public void Should_remove_given_size_when_bucket_is_full()
        {
            var state = new TokenBucketState(1000, 0.001, 1);
            state.UpdateTokenCount(2, 1);
            state.BucketTokenCount.Should().BeApproximately(999, 0.1);
        }

        [Fact]
        public void Bucket_should_not_overfill()
        {
            var state = new TokenBucketState(1000, 2000, 1);
            state.UpdateTokenCount(9999999, 1);
            state.BucketTokenCount.Should().BeApproximately(999, 0.1);
        }

        [Fact]
        public void Should_throw_exception_if_request_size_larger_than_bucket()
        {
            var state = new TokenBucketState(1000, 2000, 1);
            Assert.Throws<ArgumentOutOfRangeException>(() => state.UpdateTokenCount(2, 2000));
        }

        [Fact]
        public void Should_throw_exception_if_sufficient_tokens_are_not_available()
        {
            // Start with 1000 tokens and a slow refill rate
            var state = new TokenBucketState(1000, 0.001, 1);
            // Remove 500
            state.UpdateTokenCount(2, 500);
            // Remove 499 more right after
            state.UpdateTokenCount(3, 499);
            // Try to remove another 500
            Assert.Throws<TokenBucketRejectedException>(() => state.UpdateTokenCount(4, 500));
        }
    }
}
