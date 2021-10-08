namespace Agrobook.Application.Veiculo.Handles
{
    using Agrobook.Application.Veiculo.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculoUpdateCommandHandle : CommandHandler, IRequestHandler<VeiculoUpdateCommand, ValidationResult>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public VeiculoUpdateCommandHandle(IOrganizacaoRepository organizacaoRepository, IMapper map)
            : base(organizacaoRepository.UnitOfWork)
        {
            _organizacaoRepository = organizacaoRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(VeiculoUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existeOrganizacao = await _organizacaoRepository.ExistsAsync(o => o.Id == request.PatrimonioId, cancellationToken);
                if (!existeOrganizacao)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.OUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var organizacao = _map.Map<Organizacoes>(request);
                await _organizacaoRepository.UpdateAsync(organizacao, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.VUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
