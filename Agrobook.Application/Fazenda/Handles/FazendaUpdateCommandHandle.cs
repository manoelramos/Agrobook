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

    public class FazendaUpdateCommandHandle : CommandHandler, IRequestHandler<FazendaUpdateCommand, ValidationResult>
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public FazendaUpdateCommandHandle(IFazendaRepository fazendaRepository, IMapper map)
            : base(fazendaRepository.UnitOfWork)
        {
            _fazendaRepository = fazendaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FazendaUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existeFazenda = _fazendaRepository.ExistsAsync(o => o.Id == request.Id, cancellationToken).GetAwaiter().GetResult();
                if (!existeFazenda)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.FUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var fazenda = _map.Map<Fazendas>(request);
                await _fazendaRepository.UpdateAsync(fazenda, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.FUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
