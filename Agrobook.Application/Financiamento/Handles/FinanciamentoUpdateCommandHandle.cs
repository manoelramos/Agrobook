namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Financiamento.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class FinanciamentoUpdateCommandHandle : CommandHandler, IRequestHandler<FinanciamentoUpdateCommand, ValidationResult>
    {
        private readonly IFinanciamentoRepository _repository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public FinanciamentoUpdateCommandHandle(IFinanciamentoRepository repository, IMapper map)
            : base(repository.UnitOfWork)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FinanciamentoUpdateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var existeFinanciamento= await _repository.ExistsAsync(o => o.Id == command.Id, cancellationToken);
                if (!existeFinanciamento)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.FINUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var financiamentos = _map.Map<Financiamentos>(command);
                await _repository.UpdateAsync(financiamentos, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.FINUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
