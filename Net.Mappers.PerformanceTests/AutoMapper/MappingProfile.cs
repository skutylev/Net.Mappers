using AutoMapper;
using Net.Mappers.PerformanceTests.Contracts;

namespace Net.Mappers.PerformanceTests.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<EntityObject, EntityDto>()
            .ForMember(dest => dest.Id, o => o.MapFrom(src => src.Id))
            .ForMember(dest => dest.Type, o => o.MapFrom(src => src.Type))
            .ForMember(dest => dest.Name, o => o.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, o => o.MapFrom(src => src.Description))
            .ForMember(dest => dest.StartDate, o => o.MapFrom(src => src.StartDate))
            .ForMember(dest => dest.UpdateDate, o => o.MapFrom(src => src.UpdateDate))
            .ForMember(dest => dest.Client, o => o.MapFrom(src => new ClientDto {Id = src.ClientId}));
    }
}