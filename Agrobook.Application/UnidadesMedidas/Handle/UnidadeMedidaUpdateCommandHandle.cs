namespace Agrobook.Application.UnidadesMedidas.Handles
{
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.UnidadesMedidas.Commmand;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using Agrobook.Domain.Models.Base;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnidadeMedidaUpdateCommandHandle : CommandHandler, IRequestHandler<UnidadeMedidaUpdateCommand, ValidationResult>
    {
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public UnidadeMedidaUpdateCommandHandle(IUnidadeMedidaRepository unidadeMedidaRepository, IMapper map)
            : base(unidadeMedidaRepository.UnitOfWork)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(UnidadeMedidaUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existeUnidade = await _unidadeMedidaRepository.ExistsAsync(o => o.Id == command.Id, cancellationToken);
                if (!existeUnidade)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.UMUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var unidade = _map.Map<UnidadesMedidasAgro>(command);
                await _unidadeMedidaRepository.UpdateAsync(unidade, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.UMUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
