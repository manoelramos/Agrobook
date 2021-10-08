namespace Agrobook.Application.Veiculo.Handles
{
    using Agrobook.Application.Veiculo.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculoDeleteCommandHandle : CommandHandler, IRequestHandler<VeiculoDeleteCommand, ValidationResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _map;

        public VeiculoDeleteCommandHandle(IVeiculoRepository veiculoRepository, IMapper map)
            : base(veiculoRepository.UnitOfWork)
        {
            _veiculoRepository = veiculoRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(VeiculoDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacao = _map.Map<Organizacoes>(await _veiculoRepository.GetByIdAsync(request.PatrimonioId, cancellationToken));
                await _veiculoRepository.DeleteAsync(organizacao, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.VDC, ex.InnerException?.Message));
                return error;
            }
        }
    }
}
