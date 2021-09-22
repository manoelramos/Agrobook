namespace Agrobook.Api.Configurations
{
    using Agrobook.Api.PipelineBehaviors;
    using Agrobook.Application.Localidade.Handles;
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Handles;
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Enderecos;
    using Agrobook.Infra.Data.Repositories.Localidade;
    using Agrobook.Infra.Data.Repositories.Organizacao;
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
            services.AddDbContext<ApplicationContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IPaisesRepository, PaisRepository>();
            services.AddScoped<IEstadosRepository, EstadoRepository>();
            services.AddScoped<IEnderecosRepository, EnderecosRepository>();
        }

        public static void RegisterMediatr(this IServiceCollection services)
        {

            //services.AddValidatorsFromAssembly(typeof(Startup).Assembly);

            services.AddValidatorsFromAssembly(Assembly.Load("Agrobook.Application"));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));

            services.AddScoped<IRequestHandler<OrganizacaoQuery, List<OrganizacaoResponse>>, OrganizacaoQueryHandle>();
            services.AddScoped<IRequestHandler<PaisesQuery, List<PaisResponse>>, PaisesQueryHandle>();
            services.AddScoped<IRequestHandler<EstadosQuery, List<EstadoResponse>>, EstadosQueryHandle>();
            services.AddScoped<IRequestHandler<OrganizacaoCreateCommand, ValidationResult>, OrganizacaoCreateCommandHandle>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper((new MappingProfile()).GetType());
            //services.AddSingleton<JwtSettings>();
            //services.AddScoped<IJwtService, JwtService>();
        }
    }
}
