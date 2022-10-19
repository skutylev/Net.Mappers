using Mapster;
using Net.Mappers.PerformanceTests.Contracts;

namespace Net.Mappers.PerformanceTests.Mapster;

public class MappingProfile : TypeAdapterConfig
{
    public MappingProfile()
    {
        ForType<EntityObject, EntityDto>()
            .Map(dest => dest.Id, src => src.Id)
            .Map(dest => dest.Name, src => src.Name);
    }
}