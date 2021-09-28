﻿namespace Agrobook.Api.Configurations
{
    using Agrobook.Api.PipelineBehaviors;
    using Agrobook.Application.Localidade.Handles;
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Handles;
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Handlers;
    using Agrobook.Application.PessoaFisica.Queries;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Infra.Data.Context;
    using Agrobook.Infra.Data.Repositories.Colaborador;
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

            services.AddScoped<IEstadosRepository, EstadoRepository>();
            services.AddScoped<IEnderecosRepository, EnderecosRepository>();
            services.AddScoped<IOrganizacaoRepository, OrganizacaoRepository>();
            services.AddScoped<IAssociadosRepository, AssociadoRepository>();
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

            services.AddScoped<IRequestHandler<AssociadoCreateCommand, ValidationResult>, PessoaFisicaCreateCommandHandle>();
            services.AddScoped<IRequestHandler<PessoaFisicaQuery, List<AssociadoResponse>>, PessoaFisicaQueryHandle>();

            services.AddScoped<IRequestHandler<EstadosQuery, List<EstadoResponse>>, EstadosQueryHandle>();
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddAutoMapper((new MappingProfile()).GetType());
            //services.AddSingleton<JwtSettings>();
            //services.AddScoped<IJwtService, JwtService>();
        }
    }
}
