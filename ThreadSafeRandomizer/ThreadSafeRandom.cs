// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
#if !NET6_0_OR_GREATER
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
    public static Random Instance
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => Random.Shared;
    }
#else
    public static Random Instance
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        get => _random ??= new Random(Interlocked.Increment(ref _seed));
    }
        
    private static int _seed = Environment.TickCount;

    [ThreadStatic]
    private static Random? _random;
#endif
}