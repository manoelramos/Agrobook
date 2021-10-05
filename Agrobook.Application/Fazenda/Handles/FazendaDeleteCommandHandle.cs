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

    public class FazendaDeleteCommandHandle : CommandHandler, IRequestHandler<FazendaDeleteCommand, ValidationResult>
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IMapper _map;

        public FazendaDeleteCommandHandle(IFazendaRepository fazendaRepository, IMapper map)
            : base(fazendaRepository.UnitOfWork)
        {
            _fazendaRepository = fazendaRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(FazendaDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var organizacao = _map.Map<Fazendas>(await _fazendaRepository.GetByIdAsync(request.Id, cancellationToken));
                await _fazendaRepository.DeleteAsync(organizacao, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.FDC , ex.InnerException?.Message));
                return error;
            }
        }
    }
}
