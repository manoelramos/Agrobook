namespace Agrobook.Application.Fazenda.Handles
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

    public class ImovelUpdateCommandHandle : CommandHandler, IRequestHandler<ImovelUpdateCommand, ValidationResult>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public ImovelUpdateCommandHandle(IPatrimonioRepository patrimonioRepository, IMapper map)
            : base(patrimonioRepository.UnitOfWork)
        {
            _patrimonioRepository = patrimonioRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(ImovelUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existeImovel = await _patrimonioRepository.ExistsAsync(o => o.Imovel.Id == request.Id, cancellationToken);
                if (!existeImovel)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.IUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var patrimonio = _map.Map<Patrimonios>(request);
                await _patrimonioRepository.UpdateAsync(patrimonio, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.IUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
