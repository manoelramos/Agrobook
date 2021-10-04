namespace Agrobook.Application.PessoaJuridica.Handlers
{
    using Agrobook.Application.PessoaJuridica.Queries;
    using Agrobook.Application.PessoaJuridica.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoasJuridicasQueryHandle : IRequestHandler<PessoasJuridicasQuery, List<PessoaJuridicaResponse>>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoasJuridicasQueryHandle(IAssociadosRepository associadosRepository, IMapper map)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<List<PessoaJuridicaResponse>> Handle(PessoasJuridicasQuery request, CancellationToken cancellationToken)
        {
            var entities = await _associadosRepository.
                     Include(e => e.PessoaJuridica).
                     Include(e => e.Endereco).
                     Include(c => c.DadosBancarios).
                     Include(c => c.Contatos).
                     Include(d => d.Documentos).
                 Where(x => x.Ativo == request.Active).
                 ToListAsync(cancellationToken: cancellationToken);

            var associado = _map.Map<List<PessoaJuridicaResponse>>(entities);
            return associado;
        }
    }
}
