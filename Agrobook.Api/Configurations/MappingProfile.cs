namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.CategoriaDespesa.Responses;
    using Agrobook.Application.Common;
    using Agrobook.Application.Cultura.Responses;
    using Agrobook.Application.Despesa.Commands;
    using Agrobook.Application.DetalhesPatrimonio.Commands;
    using Agrobook.Application.DetalhesPatrimonio.Responses;
    using Agrobook.Application.Fazenda.Commands;
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Application.Financiamento.Commands;
    using Agrobook.Application.Financiamento.Responses;
    using Agrobook.Application.Imoveis.Commands;
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.Parcela.Commands;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Application.Veiculo.Responses;
    using Agrobook.Domain.Models;
    using Agrobook.Domain.Models.Base;
    using Agrobook.Domain.Models.Caixa;
    using Agrobook.Domain.Models.Parceiro;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using Agrobook.Domain.Models.Producao;
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UnidadesMedidas, UnidadeMedidaResponse>().ReverseMap();

            CreateMap<Estados, EstadoResponse>().ReverseMap();
            CreateMap<Enderecos, EnderecoResponse>().ReverseMap();
            CreateMap<Enderecos, EnderecoCommand>().ReverseMap();

            CreateMap<Classses, ClasseResponse>().ReverseMap();

            CreateMap<DetalhesPatrimonio, DetalhesPatrimonioResponse>().ReverseMap();
            CreateMap<DetalhesPatrimonio, DetalhePatrimonioCreateCommand>().ReverseMap();

            CreateMap<Veiculos, VeiculoResponse>().ReverseMap();
            CreateMap<Culturas, CulturaResponse>().ReverseMap();            


            CreateMap<DadosBancarios, DadosBancariosCommand>().ReverseMap();
            CreateMap<Contatos, ContatosCommand>().ReverseMap();
            CreateMap<Documentos, DocumentosCommand>().ReverseMap();

            CreateMap<Organizacoes, OrganizacaoResponse>().ReverseMap();
            CreateMap<Organizacoes, OrganizacaoCreateCommand>().ReverseMap();
            CreateMap<Organizacoes, OrganizacaoUpdateCommand>().ReverseMap();

            CreateMap<Fazendas, FazendaResponse>().ReverseMap();
            CreateMap<Fazendas, FazendaCreateCommand>().ReverseMap();
            
            CreateMap<CategoriasDespesas, CategoriaDespesaResponse>().ReverseMap();
            

            CreateMap<Imoveis, ImovelCreateCommand>().ReverseMap();
            CreateMap<Imoveis, ImovelResponse>().ReverseMap();
            CreateMap<Patrimonios, FazendaCreateCommand>().ReverseMap().
                ConstructUsing((source, context) => new Patrimonios
                {
                    Fazenda = context.Mapper.Map<Fazendas>(source)
                }).ForMember(x => x.Imovel, opt => opt.Ignore());

            CreateMap<Patrimonios, ImovelCreateCommand>().ReverseMap().
                ConstructUsing((source, context) => new Patrimonios
                {
                    Imovel = context.Mapper.Map<Imoveis>(source)
                }).ForMember(x => x.Fazenda, opt => opt.Ignore());

            CreateMap<Associados, PessoaFisicaCreateCommand>().ReverseMap();
            
            CreateMap<Associados, AssociadoResponse>().ReverseMap();

            CreateMap<Safras, SafraResponse>().ReverseMap();
            CreateMap<Patrimonios, PatrimonioResponse>().ReverseMap();
            CreateMap<Parcelas, ParcelaResponse>().ReverseMap();
            
            CreateMap<Despesas, DespesaCreateCommand>().ReverseMap();
            CreateMap<Parcelas, ParcelaCreateCommand>().ReverseMap();

            CreateMap<Fisicas, PessoaFisicaCommand>().ReverseMap();
            CreateMap<PessoaFisicaResponse, Associados>().ReverseMap();
            CreateMap<PessoaFisicaResponse, Associados>().                
                ForMember(x => x.PessoaJuridica, opt => opt.Ignore()).
                ForMember(x => x.PessoaFisica, opt => opt.Ignore()).
                ForMember(x => x.Contatos, opt => opt.Ignore()).
                ForMember(x => x.DadosBancarios, opt => opt.Ignore()).
                ForMember(x => x.Contratacoes, opt => opt.Ignore()).
                ForMember(x => x.Documentos, opt => opt.Ignore()).
                ForMember(x => x.Endereco, opt => opt.Ignore());


            CreateMap<PessoaJuridicaResponse, Associados>().ReverseMap();
            CreateMap<PessoaJuridicaResponse, Associados>().
                ForMember(x => x.PessoaJuridica, opt => opt.Ignore()).
                ForMember(x => x.PessoaFisica, opt => opt.Ignore()).
                ForMember(x => x.Contatos, opt => opt.Ignore()).
                ForMember(x => x.DadosBancarios, opt => opt.Ignore()).
                ForMember(x => x.Contratacoes, opt => opt.Ignore()).
                ForMember(x => x.Documentos, opt => opt.Ignore()).
                ForMember(x => x.Endereco, opt => opt.Ignore());

            CreateMap<Financiamentos, FinanciamentoResponse>().ReverseMap();
            CreateMap<Financiamentos, FinanciamentoCreateCommand>().ReverseMap();
            CreateMap<Financiamentos, FinanciamentoUpdateCommand>().ReverseMap();          


        }
    }
}

