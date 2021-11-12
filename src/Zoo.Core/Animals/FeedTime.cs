using System;

namespace Zoo.Core.Animals
{
    public class FeedTime
    {
        public FeedTime(DateTime time)
        {
            Time = time;
        }

        public DateTime Time { get; private set; }
    }
}
