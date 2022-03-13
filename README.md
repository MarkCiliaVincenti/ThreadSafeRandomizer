# ![ThreadSafeRandomizer](https://raw.githubusercontent.com/MarkCiliaVincenti/ThreadSafeRandomizer/master/logo32.png) ThreadSafeRandomizer
 [![GitHub Workflow Status](https://img.shields.io/github/workflow/status/MarkCiliaVincenti/ThreadSafeRandomizer/.NET?logo=github&style=for-the-badge)](https://actions-badge.atrox.dev/MarkCiliaVincenti/ThreadSafeRandomizer/goto?ref=master) [![Nuget](https://img.shields.io/nuget/v/ThreadSafeRandomizer?label=ThreadSafeRandomizer&logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/ThreadSafeRandomizer) [![Nuget](https://img.shields.io/nuget/dt/ThreadSafeRandomizer?logo=nuget&style=for-the-badge)](https://www.nuget.org/packages/ThreadSafeRandomizer)

An efficient thread-safe randomizer.

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
var myNum = ThreadSafeRandomizer.Instance.Next();
```
