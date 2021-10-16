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

    public class FinanciamentoDeleteCommandHandle : CommandHandler, IRequestHandler<FinanciamentoDeleteCommand, ValidationResult>
    {
        private readonly IFinanciamentoRepository _repository;
        private readonly IMapper _map;

        public FinanciamentoDeleteCommandHandle(IFinanciamentoRepository repository, IMapper map)
            : base(repository.UnitOfWork)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FinanciamentoDeleteCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var financiamento = _map.Map<Organizacoes>(await _repository.GetByIdAsync(command.Id, cancellationToken));
                await _repository.DeleteAsync(financiamento, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.FINDC, ex.InnerException?.Message));
                return error;
            }
        }
    }
}
