namespace Agrobook.Api.Configurations
{
    using Agrobook.Infra.Data.Context;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjectionConfiguration
    {

        public static void RegisterRepositories(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>();
        }

        public static void RegisterMediatr(this IServiceCollection services)
        {
            //services.AddScoped(typeof(IPipelineBehavior<,>), typeof(RequestsValidationMiddleware<,>));
            //services.AddScoped<IRequestHandler<AuthenticateQuery, Response>, AuthenticateCommandHandle>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            //var mappers = AutoMapperConfig.Setup();
            //services.AddAutoMapper(mappers);
            //services.AddSingleton<JwtSettings>();
            //services.AddScoped<IJwtService, JwtService>();
        }
    }
}
