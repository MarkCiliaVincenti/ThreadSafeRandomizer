﻿// Copyright (c) All contributors. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ThreadSafeRandomizer.SourceGenerator;

/// <summary>
/// Source generator for ThreadSafeRandomizer.
/// </summary>
[Generator]
internal sealed class Generator : IIncrementalGenerator
{
    private static readonly Assembly Assembly = typeof(Generator).Assembly;

    /// <summary>
    /// <inheritdoc cref="IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext)"/>
    /// </summary>
    /// <param name="context"><inheritdoc cref="IncrementalGeneratorInitializationContext"/></param>
    public void Initialize(IncrementalGeneratorInitializationContext context)
        => context.RegisterSourceOutput(context.CompilationProvider, Generate);

    private static void Generate(SourceProductionContext context, Compilation compilation)
    {
        var isReferenced = compilation.ReferencedAssemblyNames
            .Any(x => x.Name == "ThreadSafeRandomizer");

        if (isReferenced)
        {
            // If the runtime package is referenced, we shouldn't emit the code.
            return;
        }

        foreach (var resource in Assembly.GetManifestResourceNames())
        {
            Generate(context, resource);
        }
    }

    private static void Generate(SourceProductionContext context, string resourceName)
    {
        using var stream = Assembly.GetManifestResourceStream(resourceName);
        using var streamReader = new StreamReader(stream);
        var text = streamReader.ReadToEnd();

        var split = text.Split(['\n'], 4);
        if (split[3].LastOrDefault() == '\r')
        {
            context.AddSource(resourceName, $"{split[0]}\n{split[1]}\n{split[2]}\n#define SOURCE_GENERATOR\r\n{split[3]}");
        }
        else
        {
            context.AddSource(resourceName, $"{split[0]}\n{split[1]}\n{split[2]}\n#define SOURCE_GENERATOR\n{split[3]}");
        }
    }
}
