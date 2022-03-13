using System;
using System.Threading;

namespace ThreadSafeRandomizer
{
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

        public static Random Instance => _local.Value;
    }
}