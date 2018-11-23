using FluentAssertions;
using Polly.TokenBucket;
using Xunit;

namespace Polly.SharedSpecs.TokenBucket
{
    public class TokenBucketStateSpecs
    {
        [Fact]
        public void Test()
        {
            var state = new TokenBucketState(1000, 0.1, 1);
            state.UpdateTokenCount(2, 1);
            state.BucketTokenCount.Should().Be(999);
        }
    }
}
