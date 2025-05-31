# ![ThreadSafeRandomizer](https://raw.githubusercontent.com/MarkCiliaVincenti/ThreadSafeRandomizer/master/logo32.png)&nbsp;ThreadSafeRandomizer
 [![GitHub Workflow Status](https://img.shields.io/github/actions/workflow/status/MarkCiliaVincenti/ThreadSafeRandomizer/dotnet.yml?branch=master&logo=github&style=flat)](https://actions-badge.atrox.dev/MarkCiliaVincenti/ThreadSafeRandomizer/goto?ref=master) [![Nuget](https://img.shields.io/nuget/v/ThreadSafeRandomizer?label=ThreadSafeRandomizer&logo=nuget&style=flat)](https://www.nuget.org/packages/ThreadSafeRandomizer) [![Nuget](https://img.shields.io/nuget/dt/ThreadSafeRandomizer?logo=nuget&style=flat)](https://www.nuget.org/packages/ThreadSafeRandomizer) [![Codacy Grade](https://img.shields.io/codacy/grade/0484dc914e334c84836d22e9f884225e?style=flat)](https://app.codacy.com/gh/MarkCiliaVincenti/ThreadSafeRandomizer/dashboard) [![Codecov](https://img.shields.io/codecov/c/github/MarkCiliaVincenti/ThreadSafeRandomizer?label=coverage&logo=codecov&style=flat)](https://app.codecov.io/gh/MarkCiliaVincenti/ThreadSafeRandomizer)

An efficient thread-safe randomizer that can optionally be used as a source generator.

## Installation
The recommended means is to use [NuGet](https://www.nuget.org/packages/ThreadSafeRandomizer), but you could also download the source code from [here](https://github.com/MarkCiliaVincenti/ThreadSafeRandomizer/releases).

## Usage
Replace:
```csharp
var random = new Random();
var myNum = random.Next();
```

With:
```csharp
var myNum = ThreadSafeRandom.Instance.Next();
```

## Source Generator
The usage as a source generator is almost identical to using it as a dependency. The only difference is changing:

```xml
<PackageReference Include="ThreadSafeRandomizer" Version="2.0.3" />  
```

to:

```xml
<PackageReference Include="ThreadSafeRandomizer" Version="2.0.3">
  <PrivateAssets>all</PrivateAssets>
  <IncludeAssets>analyzers</IncludeAssets>
</PackageReference>
```
