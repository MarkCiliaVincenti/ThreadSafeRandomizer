using System;
using System.Threading;

namespace ThreadSafeRandomizer
{
    /// <summary>
    /// An efficient thread-safe randomizer.
    /// </summary>
    public class ThreadSafeRandomizer
    {
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

        /// <summary>
        /// Thread-safe <see cref="Random"/> instance.
        /// </summary>
        public static Random Instance => _local.Value;
    }
}