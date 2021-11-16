using System;
using Zoo.Core.Employees;

namespace Zoo.Core.Animals
{
    public class FeedTime
    {
        public DateTime Time { get; private set; }
        public ZooKeeper FedByZooKeeper { get; private set; }

        public FeedTime(DateTime time, ZooKeeper zooKeeper)
        {
            Time = time;
            FedByZooKeeper = zooKeeper;
        }
    }
}
