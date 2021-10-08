namespace Agrobook.Application.Veiculo.Handles
{
    using Agrobook.Application.Veiculo.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.PatrimonioGroup;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculoCreateCommandHandle : CommandHandler, IRequestHandler<VeiculoCreateCommand, ValidationResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _map;

        public VeiculoCreateCommandHandle(IVeiculoRepository veiculoRepository, IMapper map)
            : base(veiculoRepository.UnitOfWork)
        {
            _veiculoRepository = veiculoRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(VeiculoCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var veiculo = _map.Map<Veiculos>(request);
                await _veiculoRepository.CreateAsync(veiculo, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.VCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
