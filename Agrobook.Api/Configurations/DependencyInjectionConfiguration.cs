namespace Agrobook.Api.Configurations
{
    using Agrobook.Api.PipelineBehaviors;
    using Agrobook.Application.Cultura.Handles;
    using Agrobook.Application.Cultura.Queries;
    using Agrobook.Application.Cultura.Responses;
    using Agrobook.Application.Despesa.Commands;
    using Agrobook.Application.Despesa.Queries;
    using Agrobook.Application.Despesa.Response;
    using Agrobook.Application.DetalhesPatrimonio.Commands;
    using Agrobook.Application.DetalhesPatrimonio.Handles;
    using Agrobook.Application.DetalhesPatrimonio.Queries;
    using Agrobook.Application.DetalhesPatrimonio.Responses;
    using Agrobook.Application.Fazenda.Commands;
    using Agrobook.Application.Fazenda.Handles;
    using Agrobook.Application.Fazenda.Queries;
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Application.Imoveis.Commands;
    using Agrobook.Application.Imoveis.Handles;
    using Agrobook.Application.Imoveis.Queries;
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Application.Localidade.Handles;
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Handles;
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Handlers;
    using Agrobook.Application.PessoaFisica.Handles;
    using Agrobook.Application.PessoaFisica.Queries;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Application.PessoaJuridica.Commands;
    using Agrobook.Application.PessoaJuridica.Handlers;
    using Agrobook.Application.PessoaJuridica.Handles;
    using Agrobook.Application.PessoaJuridica.Queries;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Application.UnidadesMedidas.Commmand;
    using Agrobook.Application.UnidadesMedidas.Handles;
    using Agrobook.Application.UnidadesMedidas.Queries;
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Application.Veiculo.Commands;
    using Agrobook.Application.Veiculo.Handles;
    using Agrobook.Application.Veiculo.Queries;
    using Agrobook.Application.Veiculo.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Colaborador;
    using Agrobook.Infra.Data.Repositories.Cultura;
    using Agrobook.Infra.Data.Repositories.Despesas;
    using Agrobook.Infra.Data.Repositories.Enderecos;
    using Agrobook.Infra.Data.Repositories.Fazenda;
    using Agrobook.Infra.Data.Repositories.Imoveis;
    using Agrobook.Infra.Data.Repositories.Localidade;
    using Agrobook.Infra.Data.Repositories.Organizacao;
    using Agrobook.Infra.Data.Repositories.Patrimonio;
    using Agrobook.Infra.Data.Repositories.UnidadesMedidas;
    using Agrobook.Infra.Data.Repositories.Veiculo;
    using FluentValidation;
    using FluentValidation.Results;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Collections.Generic;
    using System.Reflection;

    public static class DependencyInjectionConfiguration
    {

        public static void RegisterRepositories(this IServiceCollection services)
        {
            //// Ensure the database is created.
            //context.Database.EnsureCreated();

            services.AddDbContext<ApplicationContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddScoped<IEstadosRepository, EstadoRepository>();
            services.AddScoped<IEnderecosRepository, EnderecosRepository>();
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IAssociadosRepository, AssociadoRepository>();
            services.AddScoped<IUnidadeMedidaRepository, UnidadeMedidaRepository>();
            services.AddScoped<IFazendaRepository, FazendaRepository>();
            services.AddScoped <IPatrimonioRepository, PatrimonioRepository>();
            services.AddScoped <IImovelRepository, ImovelRepository>();
            services.AddScoped<IDetalhePatrimonioRepository, DetalhePatrimonioRepository>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IDespesaRepository, DespesaRepository>();
            services.AddScoped<ICulturaRepository, CulturaRepository>();
        }

        public static void RegisterMediatr(this IServiceCollection services)
        {
            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddValidatorsFromAssembly(Assembly.Load("Agrobook.Application"));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));

            services.AddScoped<IRequestHandler<OrganizacaoQuery, List<OrganizacaoResponse>>, OrganizacaoQueryHandle>();
            services.AddScoped<IRequestHandler<OrganizacaoByIdQuery, OrganizacaoResponse>, OrganizacaoByIdQueryHandle>();
            services.AddScoped<IRequestHandler<OrganizacaoCreateCommand, ValidationResult>, OrganizacaoCreateCommandHandle>();
            services.AddScoped<IRequestHandler<OrganizacaoDeleteCommand, ValidationResult>, OrganizacaoDeleteCommandHandle>();
            services.AddScoped<IRequestHandler<OrganizacaoUpdateCommand, ValidationResult>, OrganizacaoUpdateCommandHandle>();

            services.AddScoped<IRequestHandler<FazendaQuery, List<FazendaResponse>>, FazendasQueryHandle>();
            services.AddScoped<IRequestHandler<FazendaByIdQuery, FazendaResponse>, FazendaByIdQueryHandle>();
            services.AddScoped<IRequestHandler<FazendaCreateCommand, ValidationResult>, FazendaCreateCommandHandle>();
            services.AddScoped<IRequestHandler<FazendaDeleteCommand, ValidationResult>, FazendaDeleteCommandHandle>();
            services.AddScoped<IRequestHandler<FazendaUpdateCommand, ValidationResult>, FazendaUpdateCommandHandle>();

            services.AddScoped<IRequestHandler<PessoaFisicaCreateCommand, ValidationResult>, PessoaFisicaCreateCommandHandle>();
            services.AddScoped<IRequestHandler<PessoaFisicaUpdateCommand, ValidationResult>, PessoaFisicaUpdateCommanHandle>();
            services.AddScoped<IRequestHandler<PessoaFisicaDeleteCommand, ValidationResult>, PessoaFisicaDeleteCommandHandle>();
            services.AddScoped<IRequestHandler<PessoasFisicasQuery, List<PessoaFisicaResponse>>, PessoasFisicasQueryHandle>();
            services.AddScoped<IRequestHandler<PessoaFisicaByIdQuery, PessoaFisicaResponse>, PessoaFisicaByIdQueryHandle>();

            services.AddScoped<IRequestHandler<PessoasJuridicasQuery, List<PessoaJuridicaResponse>>, PessoasJuridicasQueryHandle>();
            services.AddScoped<IRequestHandler<PessoaJuridicaByIdQuery, PessoaJuridicaResponse>, PessoaJuridicaByIdQueryHandle>();
            services.AddScoped<IRequestHandler<PessoaJuridicaCreateCommand, ValidationResult>, PessoaJuridicaCreateCommandHandle>();
            services.AddScoped<IRequestHandler<PessoaJuridicaUpdateCommand, ValidationResult>, PessoaJuridicaUpdateCommanHandle>();
            services.AddScoped<IRequestHandler<PessoaJuridicaDeleteCommand, ValidationResult>, PessoaJuridicaDeleteCommandHandle>();
            
            services.AddScoped<IRequestHandler<EstadosQuery, List<EstadoResponse>>, EstadosQueryHandle>();
            services.AddScoped<IRequestHandler<UnidadesMedidasQuery, List<UnidadeMedidaResponse>>, UnidadesMedidasQueryHandle>();
            services.AddScoped<IRequestHandler<UnidadeMedidaCreateCommand, ValidationResult>, UnidadeMedidaCreateCommandHandle>();
            services.AddScoped<IRequestHandler<UnidadeMedidaUpdateCommand, ValidationResult>, UnidadeMedidaUpdateCommandHandle>();

            services.AddScoped<IRequestHandler<ImovelQuery, List<ImovelResponse>>, ImoveisQueryHandle>();
            services.AddScoped<IRequestHandler<ImovelByIdQuery, ImovelResponse>, ImovelByIdQueryHandle>();
            services.AddScoped<IRequestHandler<ImovelCreateCommand, ValidationResult>, ImovelCreateCommandHandle>();
            services.AddScoped<IRequestHandler<ImovelDeleteCommand, ValidationResult>, ImovelDeleteCommandHandle>();
            services.AddScoped<IRequestHandler<ImovelUpdateCommand, ValidationResult>, ImovelUpdateCommandHandle>();
            
            services.AddScoped<IRequestHandler<DetalhesByPatrimonioIdQuery, List<DetalhesPatrimonioResponse>>, DetalhesByPatrimonioIdHandle>();
            services.AddScoped<IRequestHandler<DetalhePatrimonioCreateCommand, ValidationResult>, DetalhesPatrimonioCreateCommandHandle>();

            services.AddScoped<IRequestHandler<VeiculosQuery, List<VeiculoResponse>>, VeiculosQueryHandle>();
            services.AddScoped<IRequestHandler<VeiculoByIdQuery, VeiculoResponse>, VeiculoByIdQueryHandle>();
            services.AddScoped<IRequestHandler<VeiculoCreateCommand, ValidationResult>, VeiculoCreateCommandHandle>();
            services.AddScoped<IRequestHandler<VeiculoUpdateCommand, ValidationResult>, VeiculoUpdateCommandHandle>();
            services.AddScoped<IRequestHandler<VeiculoDeleteCommand, ValidationResult>, VeiculoDeleteCommandHandle>();

            services.AddScoped<IRequestHandler<DespesasByCategoryQuery, DespesaResponse>, DespesasByCategoryQueryHandle>();
            services.AddScoped<IRequestHandler<DespesaCreateCommand, ValidationResult>, DespesaCreateCommandHandle>();

            services.AddScoped<IRequestHandler<CulturasQuery, CulturaResponse>, CulturaQueryHandle>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper((new MappingProfile()).GetType());
            //services.AddSingleton<JwtSettings>();
            //services.AddScoped<IJwtService, JwtService>();
        }
    }
}

