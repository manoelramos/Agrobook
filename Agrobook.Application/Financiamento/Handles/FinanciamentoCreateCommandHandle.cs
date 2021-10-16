namespace Agrobook.Application.Financiamento.Handles
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

    public class FinanciamentoCreateCommandHandle : CommandHandler, IRequestHandler<FinanciamentoCreateCommand, ValidationResult>
    {
        private readonly IFinanciamentoRepository _repository;
        private readonly IMapper _map;

        public FinanciamentoCreateCommandHandle(IFinanciamentoRepository repository, IMapper map) : base(repository.UnitOfWork)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FinanciamentoCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var financiamento = _map.Map<Financiamentos>(command);
                await _repository.CreateAsync(financiamento, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.FINCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
