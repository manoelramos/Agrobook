namespace Agrobook.Application.PessoaFisica.Handlers
{
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using Agrobook.Domain.Models.Parceiro;
    using AutoMapper;
    using FluentValidation.Results;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoaFisicaUpdateCommanHandle : CommandHandler, IRequestHandler<PessoaFisicaUpdateCommand, ValidationResult>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;
        private readonly ValidationResult _error = new();

        public PessoaFisicaUpdateCommanHandle(IAssociadosRepository associadosRepository, IMapper map)
            : base(associadosRepository.UnitOfWork)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<ValidationResult> Handle(PessoaFisicaUpdateCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var existePessoa = _associadosRepository.ExistsAsync(o => o.Id == request.Id, cancellationToken).GetAwaiter().GetResult();
                if (!existePessoa)
                {
                    _error.Errors.Add(new ValidationFailure(Rsc_Message.OUC, Rsc_Message.RegistroNaoEncontrado));
                    return _error;
                }

                var pessoa = _map.Map<Associados>(request);
                await _associadosRepository.UpdateAsync(pessoa, cancellationToken);
                return await CommitAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _error.Errors.Add(new ValidationFailure(Rsc_Message.OUC, ex.InnerException.Message));
                return _error;
            }
        }
    }
}
