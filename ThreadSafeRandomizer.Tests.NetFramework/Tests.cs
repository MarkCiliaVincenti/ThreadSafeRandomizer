using Xunit;

namespace ThreadSafeRandomizer.Tests.NetFramework
{
    public class Tests
    {
        [Fact]
        public void TestNetFramework()
        {
            var result = ThreadSafeRandom.Instance.Next(2);
            Assert.True(result >= 0 && result < 2);
        }
    }
}
