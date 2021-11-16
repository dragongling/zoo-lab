using Xunit;

namespace Zoo.App.Tests
{
    public class ZooAppTests
    {
        [Fact]
        public void ShouldCreateZooApp()
        {
            _ = new ZooApp();
        }

        [Fact]
        public void ShouldAddZoo()
        {
            var zooApp = new ZooApp();
            var zoo = new Core.Zoo("City");
            zooApp.AddZoo(zoo);
        }
    }
}
