namespace Agrobook.Application.UnidadesMedidas.Handles
{
    using Agrobook.Application.UnidadesMedidas.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Base;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnidadeMedidaDeleteCommandHandle : CommandHandler, IRequestHandler<UnidadeMedidaDeleteCommand, ValidationResult>
    {
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;
        private readonly IMapper _map;

        public UnidadeMedidaDeleteCommandHandle(IUnidadeMedidaRepository unidadeMedidaRepository, IMapper map)
            : base(unidadeMedidaRepository.UnitOfWork)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(UnidadeMedidaDeleteCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var unidade = _map.Map<UnidadesMedidas>(await _unidadeMedidaRepository.GetByIdAsync(command.Id, cancellationToken));
                await _unidadeMedidaRepository.DeleteAsync(unidade, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors. Add(new ValidationFailure(Rsc_Message.UMDC, ex.InnerException is null? ex.Message : ex.InnerException.Message));
                return error;
            }
        }
    }
}
