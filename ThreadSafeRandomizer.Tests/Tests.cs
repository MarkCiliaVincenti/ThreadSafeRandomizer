using Xunit;

namespace ThreadSafeRandomizer.Tests.Net60
{
    public class Tests
    {
        [Fact]
        public void TestNet60()
        {
            var result = ThreadSafeRandom.Instance.Next(2);
            Assert.True(result >= 0 && result < 2);
        }
    }
}
