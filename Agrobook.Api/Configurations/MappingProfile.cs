namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.Common;
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Application.UnidadesMedidas.Commmand;
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<UnidadesMedidas, UnidadeMedidaResponse>().ReverseMap();
            CreateMap<UnidadesMedidasAgro, UnidadeMedidaResponse>().ReverseMap();
            CreateMap<UnidadesMedidas, UnidadesMedidasAgro>().ReverseMap();
            CreateMap<UnidadesMedidasAgro, UnidadeMedidaCreateCommand>().ReverseMap();
            CreateMap<UnidadesMedidasAgro, UnidadeMedidaUpdateCommand>().ReverseMap();

            CreateMap<Estados, EstadoResponse>().ReverseMap();
            CreateMap<Enderecos, EnderecoResponse>().ReverseMap();
            CreateMap<Enderecos, EnderecoCommand>().ReverseMap();

            CreateMap<DadosBancarios, DadosBancariosCommand>().ReverseMap();
            CreateMap<Contatos, ContatosCommand>().ReverseMap();
            CreateMap<Documentos, DocumentosCommand>().ReverseMap();

            CreateMap<Organizacoes, OrganizacaoResponse>().ReverseMap();
            CreateMap<Organizacoes, OrganizacaoCreateCommand>().ReverseMap();
            CreateMap<Organizacoes, OrganizacaoUpdateCommand>().ReverseMap();

            CreateMap<Fazendas, FazendaResponse>().ReverseMap();
            

            CreateMap<Associados,PessoaFisicaCreateCommand>().ReverseMap();
            
            CreateMap<Fisicas, PessoaFisicaCommand>().ReverseMap();
            CreateMap<PessoaFisicaResponse, Associados>().ReverseMap();
            CreateMap<PessoaFisicaResponse, Associados>().
                ForMember(x => x.Pagamentos, opt => opt.Ignore()).
                ForMember(x => x.PessoaJuridica, opt => opt.Ignore()).
                ForMember(x => x.PessoaFisica, opt => opt.Ignore()).
                ForMember(x => x.Contatos, opt => opt.Ignore()).
                ForMember(x => x.DadosBancarios, opt => opt.Ignore()).
                ForMember(x => x.Contratacoes, opt => opt.Ignore()).
                ForMember(x => x.Documentos, opt => opt.Ignore()).
                ForMember(x => x.Endereco, opt => opt.Ignore());


            CreateMap<PessoaJuridicaResponse, Associados>().ReverseMap();
            CreateMap<PessoaJuridicaResponse, Associados>().
                ForMember(x => x.Pagamentos, opt => opt.Ignore()).
                ForMember(x => x.PessoaJuridica, opt => opt.Ignore()).
                ForMember(x => x.PessoaFisica, opt => opt.Ignore()).
                ForMember(x => x.Contatos, opt => opt.Ignore()).
                ForMember(x => x.DadosBancarios, opt => opt.Ignore()).
                ForMember(x => x.Contratacoes, opt => opt.Ignore()).
                ForMember(x => x.Documentos, opt => opt.Ignore()).
                ForMember(x => x.Endereco, opt => opt.Ignore());
        }
    }
}

