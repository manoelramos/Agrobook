namespace Agrobook.Application.PessoaJuridica.Handlers
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

    public class PessoaJuridicaCreateCommandHandle : CommandHandler, IRequestHandler<PessoaJuridicaCreateCommand, ValidationResult>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoaJuridicaCreateCommandHandle(IAssociadosRepository associadosRepository, IMapper map) 
            : base(associadosRepository.UnitOfWork)
        {
            _map = map;
            _associadosRepository = associadosRepository;
        }

        public async Task<ValidationResult> Handle(PessoaJuridicaCreateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var associado = _map.Map<Associados>(request);
                await _associadosRepository.CreateAsync(associado, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var error = new ValidationResult();
                error.Errors.Add(new ValidationFailure(Rsc_Message.ASS, ex.InnerException.Message));
                return error;
            }
        }
    }
}
