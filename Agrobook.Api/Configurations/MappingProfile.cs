namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.Common;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Responses;
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
            CreateMap<OrganizacaoCreateCommand, Organizacoes>().ReverseMap();
            CreateMap<OrganizacaoUpdateCommand, Organizacoes>().ReverseMap();

            CreateMap<EnderecoCommand, Enderecos>().ReverseMap();

            CreateMap<AssociadoCreateCommand, Associados>().ReverseMap();
            CreateMap<PessoaFisicaCommand, PessoasFisicas>().ReverseMap();
            CreateMap<DadosBancariosCommand, DadosBancarios>().ReverseMap();
            CreateMap<ContatosCommand, Contatos>().ReverseMap();
            CreateMap<DocumentosCommand, Documentos>().ReverseMap();
            CreateMap<AssociadoResponse, Associados>().ReverseMap();
        }
    }
}
