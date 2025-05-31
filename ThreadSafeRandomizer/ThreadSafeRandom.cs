// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

#if NET6_0_OR_GREATER
using System;
#else
using System;
using System.Threading;
#endif

namespace ThreadSafeRandomizer;

/// <summary>
/// An efficient thread-safe randomizer.
/// </summary>
#if SOURCE_GENERATOR
internal
#else
public
#endif
static class ThreadSafeRandom
{
    /// <summary>
    /// Thread-safe <see cref="Random"/> instance.
    /// </summary>
#if NET6_0_OR_GREATER
    public static Random Instance => Random.Shared;
#else
    public static Random Instance => _local.Value;

    private static readonly Random _global = new();
    private static readonly ThreadLocal<Random> _local = new(() =>
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