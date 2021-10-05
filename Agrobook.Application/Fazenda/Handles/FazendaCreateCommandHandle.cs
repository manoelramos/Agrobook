namespace Agrobook.Application.Fazenda.Handles
{
    using Agrobook.Application.Fazenda.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class FazendaCreateCommandHandle : CommandHandler, IRequestHandler<FazendaCreateCommand, ValidationResult>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMapper _map;

        public FazendaCreateCommandHandle(IPatrimonioRepository patrimonioRepository, IMapper map)
            : base(patrimonioRepository.UnitOfWork)
        {
            _patrimonioRepository = patrimonioRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FazendaCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var patrimonio = _map.Map<Patrimonios>(command);
                await _patrimonioRepository.CreateAsync(patrimonio, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.FCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
