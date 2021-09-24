namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoDeleteCommandHandle : CommandHandler, IRequestHandler<OrganizacaoDeleteCommand, ValidationResult>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IMapper _map;

        public OrganizacaoDeleteCommandHandle(IOrganizacaoRepository organizacaoRepository, IMapper map)
            : base(organizacaoRepository.UnitOfWork)
        {
            _organizacaoRepository = organizacaoRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(OrganizacaoDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacao = _map.Map<Organizacoes>(await _organizacaoRepository.GetByIdAsync(request.Id, cancellationToken));
                await _organizacaoRepository.DeleteAsync(organizacao, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure("ODC", ex.InnerException?.Message));
                return error;
            }
        }
    }
}
