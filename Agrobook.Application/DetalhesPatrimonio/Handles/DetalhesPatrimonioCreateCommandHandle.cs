namespace Agrobook.Application.DetalhesPatrimonio.Handles
{
    using Agrobook.Application.DetalhesPatrimonio.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class DetalhesPatrimonioCreateCommandHandle : CommandHandler, IRequestHandler<DetalhePatrimonioCreateCommand, ValidationResult>
    {
        private readonly IDetalhePatrimonioRepository _detalhePatrimonioRepository;
        private readonly IMapper _map;

        public DetalhesPatrimonioCreateCommandHandle(IDetalhePatrimonioRepository detalhePatrimonioRepository, IMapper map)
            : base(detalhePatrimonioRepository.UnitOfWork)
        {
            _detalhePatrimonioRepository = detalhePatrimonioRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(DetalhePatrimonioCreateCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var observacao = _map.Map<DetalhesPatrimonio>(command);
                await _detalhePatrimonioRepository.CreateAsync(observacao, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.DPCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
