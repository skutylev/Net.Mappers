using AutoMapper;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using ExpressMapper;
using Mapster;
using Net.Mappers.PerformanceTests.AutoMapper;
using Net.Mappers.PerformanceTests.Contracts;
using Net.Mappers.PerformanceTests.Manual;
using Mapper = AutoMapper.Mapper;

namespace Net.Mappers.PerformanceTests;

[SimpleJob(RunStrategy.Throughput, RuntimeMoniker.Net60)]
[MinColumn, MaxColumn, MeanColumn]
public class MappingBenchmark
{
    private EntityObject _sourceObject;
    private readonly ICollection<EntityObject> _sourceObjectCollection100 = new List<EntityObject>();
    private readonly ICollection<EntityObject> _sourceObjectCollection1000 = new List<EntityObject>();
    private readonly ICollection<EntityObject> _sourceObjectCollection10000 = new List<EntityObject>();
    private Mapper _autoMapper;
    private Random _random;

    [GlobalSetup]
    public void Setup()
    {
        _random = new Random();
        _sourceObject = new EntityObject
        {
            Id = new Guid(),
            Name = "Test entity",
            Description = "Test Description",
            ClientId = 1001,
            StartDate = DateTime.Now,
            UpdateDate = DateTime.Now
        };

        for (var i = 0; i < 100; i++)
        {
            _sourceObjectCollection100.Add(new EntityObject
            {
                Id = new Guid(),
                Type = "Some type",
                Name = "Some name",
                Description = "Some Description",
                ClientId = _random.NextInt64(),
                StartDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble()),
                UpdateDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble())
            });
        }

        for (var i = 0; i < 1000; i++)
        {
            _sourceObjectCollection1000.Add(new EntityObject
            {
                Id = new Guid(),
                Type = "Some type",
                Name = "Some name",
                Description = "Some Description",
                ClientId = _random.NextInt64(),
                StartDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble()),
                UpdateDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble())
            });
        }

        for (var i = 0; i < 10000; i++)
        {
            _sourceObjectCollection10000.Add(new EntityObject
            {
                Id = new Guid(),
                Type = "Some type",
                Name = "Some name",
                Description = "Some Description",
                ClientId = _random.NextInt64(),
                StartDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble()),
                UpdateDate = DateTime.UtcNow.AddMilliseconds(_random.NextDouble())
            });
        }

        var config = new MapperConfiguration(a => a.AddProfile(typeof(MappingProfile)));
        _autoMapper = new Mapper(config);
        ExpressMapper.Mapper.Register<EntityObject, EntityDto>().CompileTo(CompilationTypes.Source);
    }

    [Benchmark]
    public EntityDto Manual()
    {
        return _sourceObject.MapToDto();
    }
    
    [Benchmark]
    public EntityDto AutoMapper()
    {
        return _autoMapper.Map<EntityDto>(_sourceObject);
    }

    [Benchmark]
    public EntityDto Mapster()
    {
        return _sourceObject.Adapt<EntityDto>();
    }

    [Benchmark]
    public EntityDto ExpressMappers()
    {
        return ExpressMapper.Mapper.Map<EntityObject, EntityDto>(_sourceObject);
    }

    [Benchmark]
    public IReadOnlyCollection<EntityDto> ManualCollection100()
    {
        return _sourceObjectCollection100.Select(o => o.MapToDto()).ToArray();
    }

    [Benchmark]
    public IReadOnlyCollection<EntityDto> AutoMapperCollection100()
    {
        return _autoMapper.Map<IReadOnlyCollection<EntityDto>>(_sourceObjectCollection100);
    }
    
    [Benchmark]
    public IReadOnlyCollection<EntityDto> MapsterCollection100()
    {
        return _sourceObjectCollection100.Adapt<IReadOnlyCollection<EntityDto>>();
    }
    
    [Benchmark]
    public IReadOnlyCollection<EntityDto> ManualCollection1000()
    {
        return _sourceObjectCollection1000.Select(o => o.MapToDto()).ToArray();
    }

    [Benchmark]
    public IReadOnlyCollection<EntityDto> AutoMapperCollection1000()
    {
        return _autoMapper.Map<IReadOnlyCollection<EntityDto>>(_sourceObjectCollection1000);
    }
    
    [Benchmark]
    public IReadOnlyCollection<EntityDto> MapsterCollection1000()
    {
        return _sourceObjectCollection1000.Adapt<IReadOnlyCollection<EntityDto>>();
    }
    
    [Benchmark]
    public IReadOnlyCollection<EntityDto> ManualCollection10000()
    {
        return _sourceObjectCollection10000.Select(o => o.MapToDto()).ToArray();
    }

    [Benchmark]
    public IReadOnlyCollection<EntityDto> AutoMapperCollection10000()
    {
        return _autoMapper.Map<IReadOnlyCollection<EntityDto>>(_sourceObjectCollection10000);
    }
    
    [Benchmark]
    public IReadOnlyCollection<EntityDto> MapsterCollection10000()
    {
        return _sourceObjectCollection10000.Adapt<IReadOnlyCollection<EntityDto>>();
    }
}