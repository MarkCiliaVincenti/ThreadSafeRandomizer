using System;
using System.Threading;

namespace ThreadSafeRandomizer;

/// <summary>
/// An efficient thread-safe randomizer.
/// </summary>
public static class ThreadSafeRandom
{
    /// <summary>
    /// Thread-safe <see cref="Random"/> instance.
    /// </summary>
#if NET6_0_OR_GREATER
    public static Random Instance => Random.Shared;
#else
    public static Random Instance => _local.Value;

    private static readonly Random _global = new Random();
    private static readonly ThreadLocal<Random> _local = new ThreadLocal<Random>(() =>
    {
        int seed;
        lock (_global)
        {
            seed = _global.Next();
        }
        return new Random(seed);
    });
#endif
}