namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.Common;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Domain.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Paises, PaisResponse>().ReverseMap();
            CreateMap<Estados, EstadoResponse>().ReverseMap();
            CreateMap<Enderecos, EnderecoResponse>().ReverseMap();
            CreateMap<Organizacoes, OrganizacaoResponse>().ReverseMap();
            CreateMap<EnderecoCreateCommand, Enderecos>().ReverseMap();
            CreateMap<OrganizacaoCreateCommand, Organizacoes>().ReverseMap();
            CreateMap<OrganizacaoUpdateCommand, Organizacoes>().ReverseMap();
            CreateMap<PessoaFisicaCreateCommand, Associados>().ReverseMap();
        }
    }
}
