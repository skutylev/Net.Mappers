using BenchmarkDotNet.Running;

namespace Net.Mappers.PerformanceTests;

public static class Program
{
    public static void Main(string[] args)
    {
        var summary = BenchmarkRunner.Run<MappingBenchmark>();
    }
}