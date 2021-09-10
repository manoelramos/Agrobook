namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Domain.Models.Base;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {            
            CreateMap<PaisResponse, Paises>().ReverseMap();
            CreateMap<EstadoResponse, Estados>().ReverseMap();
        }
    }
}
