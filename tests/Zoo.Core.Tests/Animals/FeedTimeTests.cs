using System;
using Xunit;
using Zoo.Core.Employees;

namespace Zoo.Core.Animals.Tests
{
    public class FeedTimeTests
    {
        [Fact]
        public void ShouldCreateFeedTime()
        {
            var time = new DateTime(2021, 11, 12, 14, 53, 21);
            var zooKeeper = new ZooKeeper("L", "F");
            var feedTime = new FeedTime(time, zooKeeper);
            Assert.Equal(time, feedTime.Time);
        }
    }
}
