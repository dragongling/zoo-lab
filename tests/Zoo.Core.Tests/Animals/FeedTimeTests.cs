using System;
using Xunit;

namespace Zoo.Core.Animals.Tests
{
    public class FeedTimeTests
    {
        [Fact]
        public void ShouldCreateFeedTime()
        {
            var time = new DateTime(2021, 11, 12, 14, 53, 21);
            var feedTime = new FeedTime(time);
            Assert.Equal(time, feedTime.Time);
        }
    }
}
