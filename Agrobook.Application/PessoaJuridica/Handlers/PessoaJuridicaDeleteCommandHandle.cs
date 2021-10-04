namespace Agrobook.Application.PessoaJuridica.Handles
{
    using Agrobook.Application.PessoaJuridica.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Parceiro;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoaJuridicaDeleteCommandHandle : CommandHandler, IRequestHandler<PessoaJuridicaDeleteCommand, ValidationResult>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoaJuridicaDeleteCommandHandle(IAssociadosRepository associadosRepository, IMapper map)
            : base(associadosRepository.UnitOfWork)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(PessoaJuridicaDeleteCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var associado = _map.Map<Associados>(await _associadosRepository.GetByIdAsync(request.Id, cancellationToken));
                await _associadosRepository.DeleteAsync(associado, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors. Add(new ValidationFailure("ODC", ex.InnerException is null? ex.Message : ex.InnerException.Message));
                return error;
            }
        }
    }
}
