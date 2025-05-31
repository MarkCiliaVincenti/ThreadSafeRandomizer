using Xunit;

namespace ThreadSafeRandomizer.Tests;

public class Tests
{
    [Fact]
    public void Test()
    {
        var result = ThreadSafeRandom.Instance.Next(2);
        Assert.True(result >= 0 && result < 2);
    }
}
