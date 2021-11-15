using System;
using System.Collections.Generic;
using Xunit;
using Zoo.Core.Foods;
using Zoo.Core.Medicines;

namespace Zoo.Core.Animals.Tests
{
    public class AnimalTests
    {
        [Fact]
        public void ShouldAddFeedSchedule()
        {
            var penguin = new Penguin();
            var schedule = new List<int> { 7, 13, 19 };
            penguin.AddFeedSchedule(schedule);
            Assert.Equal(schedule, penguin.FeedSchedule);

            var incorrectSchedule = new List<int> { -1 };
            Assert.Throws<ArgumentOutOfRangeException>(() => penguin.AddFeedSchedule(incorrectSchedule));

            incorrectSchedule = new List<int> { 24 };
            Assert.Throws<ArgumentOutOfRangeException>(() => penguin.AddFeedSchedule(incorrectSchedule));
        }

        [Fact]
        public void ShouldGetHealedWhenSick()
        {
            var penguin = new Penguin();

            penguin.Feed(new Grass());
            Assert.True(penguin.IsSick);

            penguin.Heal(new AntiInflammatory());
            Assert.False(penguin.IsSick);
        }

        [Fact]
        public void ShouldGenerateID()
        {
            var penguin = new Penguin();
            Assert.NotEqual(0, penguin.ID);
        }
    }
}
