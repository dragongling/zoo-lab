using Xunit;

namespace Zoo.App.Tests
{
    public class ProgramTests
    {
        [Fact]
        public void ShouldRunAsExpected()
        {
            Program.Main(System.Array.Empty<string>());
        }
    }
}
