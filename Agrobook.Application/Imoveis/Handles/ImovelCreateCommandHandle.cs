namespace Agrobook.Application.Imoveis.Handles
{
    using Agrobook.Application.Imoveis.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class ImovelCreateCommandHandle : CommandHandler, IRequestHandler<ImovelCreateCommand, ValidationResult>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMapper _map;

        public ImovelCreateCommandHandle(IPatrimonioRepository patrimonioRepository, IMapper map)
            : base(patrimonioRepository.UnitOfWork)
        {
            _patrimonioRepository = patrimonioRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(ImovelCreateCommand command, CancellationToken cancellationToken)
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
                error.Errors.Add(new ValidationFailure(Rsc_Message.ICC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
