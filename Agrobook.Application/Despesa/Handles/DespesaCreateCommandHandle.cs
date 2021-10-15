namespace Agrobook.Application.Fazenda.Handles
{
    using Agrobook.Application.Despesa.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Caixa;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DespesaCreateCommandHandle : CommandHandler, IRequestHandler<DespesaCreateCommand, ValidationResult>
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IMapper _map;

        public DespesaCreateCommandHandle(IDespesaRepository despesaRepository, IMapper map)
            : base(despesaRepository.UnitOfWork)
        {
            _despesaRepository = despesaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(DespesaCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var despesa = _map.Map<Despesas>(command);
                await _despesaRepository.CreateAsync(despesa, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.DCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
