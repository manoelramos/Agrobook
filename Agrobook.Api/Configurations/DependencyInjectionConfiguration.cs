namespace Agrobook.Api.Configurations
{
    using Agrobook.Application.Localidade.Handles;
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Organizacao.Handles;
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Localidade;
    using Agrobook.Infra.Data.Repositories.Organizacao;
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionConfiguration
    {

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IPaisesRepository, PaisRepository>();
            services.AddScoped<IEstadosRepository, EstadoRepository>();
        }

        public static void RegisterMediatr(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));
            services.AddScoped<IRequestHandler<OrganizacaoQuery, Response>, OrganizacaoQueryHandle>();
            services.AddScoped<IRequestHandler<PaisesQuery, Response>, PaisesQueryHandle>();
            services.AddScoped<IRequestHandler<EstadosQuery, Response>, EstadosQueryHandle>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper((new MappingProfile()).GetType());           
            //services.AddSingleton<JwtSettings>();
            //services.AddScoped<IJwtService, JwtService>();
        }        
    }
}
