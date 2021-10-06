namespace Agrobook.Application.UnidadesMedidas.Handles
{
    using Agrobook.Application.UnidadesMedidas.Commmand;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Base;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnidadeMedidaCreateCommandHandle : CommandHandler, IRequestHandler<UnidadeMedidaCreateCommand, ValidationResult>
    {
        private readonly IUnidadeMedidaRepository _organizacaoRepository;
        private readonly IMapper _map;

        public UnidadeMedidaCreateCommandHandle(IUnidadeMedidaRepository unidadeMedidaRepository, IMapper map)
            : base(unidadeMedidaRepository.UnitOfWork)
        {
            _organizacaoRepository = unidadeMedidaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(UnidadeMedidaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var unidades = _map.Map<UnidadesMedidas>(request);
                await _organizacaoRepository.CreateAsync(unidades, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.UMCC, ex.InnerException.Message));
                return error;
            }
        }
    }
}
