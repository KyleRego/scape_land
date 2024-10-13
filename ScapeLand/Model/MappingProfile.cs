using AutoMapper;
using ScapeLand.Dtos;
using ScapeLand.Entity;

namespace ScapeLand.Model;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<OptionDto, OptionNtt>();
        CreateMap<OptionNtt, OptionDto>();
    }
}
