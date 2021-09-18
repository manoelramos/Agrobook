namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoCreateCommandHandle : CommandHandler, IRequestHandler<OrganizacaoCreateCommand, ValidationResult>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IMapper _map;

        public OrganizacaoCreateCommandHandle(IOrganizacaoRepository organizacaoRepository, IMapper map)
            : base(organizacaoRepository.UnitOfWork)
        {
            _organizacaoRepository = organizacaoRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(OrganizacaoCreateCommand request, CancellationToken cancellationToken)
        {
            var organizacao = _map.Map<Organizacoes>(request);

            if (IsValid(new OrganizacaoValidator(), organizacao))
            {
                await _organizacaoRepository.CreateAsync(organizacao, cancellationToken);
                var result = await CommitAsync(cancellationToken);
                if (result.IsValid)
                   return Success(organizacao).ValidationResult;
            }

            return Fail<Organizacoes>(await RollbackAsync(cancellationToken)).ValidationResult;
        }
    }
}
