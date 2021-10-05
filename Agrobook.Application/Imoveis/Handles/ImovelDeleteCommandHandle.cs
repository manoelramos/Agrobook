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

    public class ImovelDeleteCommandHandle : CommandHandler, IRequestHandler<ImovelDeleteCommand, ValidationResult>
    {
        private readonly IPatrimonioRepository _patrimonioRepository;
        private readonly IMapper _map;

        public ImovelDeleteCommandHandle(IPatrimonioRepository patrimonioRepository, IMapper map)
            : base(patrimonioRepository.UnitOfWork)
        {
            _patrimonioRepository = patrimonioRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(ImovelDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var patrimonio = _map.Map<Patrimonios>(await _patrimonioRepository.GetAsync(x => x.Imovel.Id == request.Id, cancellationToken));
                await _patrimonioRepository.DeleteAsync(patrimonio, cancellationToken);
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
