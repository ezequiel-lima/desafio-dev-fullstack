using AutoMapper;
using DesafioDevFullstack.Application.Dtos.Enderecos;
using DesafioDevFullstack.Domain.Entities;

namespace DesafioDevFullstack.Application.Mappings
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EnderecoExternoDto, EnderecoDto>()
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Estado, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Neighborhood))
                .ForMember(dest => dest.Rua, opt => opt.MapFrom(src => src.Street));
        }
    }
}
