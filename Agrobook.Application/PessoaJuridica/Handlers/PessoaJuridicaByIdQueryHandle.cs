namespace Agrobook.Application.PessoaJuridica.Handlers
{
    using Agrobook.Application.PessoaJuridica.Queries;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoaJuridicaByIdQueryHandle : IRequestHandler<PessoaJuridicaByIdQuery, PessoaJuridicaResponse>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoaJuridicaByIdQueryHandle(IAssociadosRepository associadosRepository, IMapper map)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<PessoaJuridicaResponse> Handle(PessoaJuridicaByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _associadosRepository.
                 Include(e => e.PessoaJuridica).
                 Include(e => e.Endereco).
                 Include(c => c.DadosBancarios).
                 Include(c => c.Contatos).
                 Include(d => d.Documentos).
             FirstOrDefaultAsync(x => x.Id == request.Id);

            var associado = _map.Map<PessoaJuridicaResponse>(entities);
            return associado;
        }
    }
}
