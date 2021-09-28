namespace Agrobook.Application.PessoaFisica.Handlers
{
    using Agrobook.Application.PessoaFisica.Queries;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoaFisicaQueryHandle : IRequestHandler<PessoaFisicaQuery, List<AssociadoResponse>>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoaFisicaQueryHandle(IAssociadosRepository associadosRepository, IMapper map)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<List<AssociadoResponse>> Handle(PessoaFisicaQuery request, CancellationToken cancellationToken)
        {
            var entities = await _associadosRepository.
                     Include(e => e.Endereco).
                     Include(c => c.DadosBancarios).
                     Include(c => c.Contatos).
                     Include(d => d.Documentos).
                 Where(x => x.Ativo == request.Active).
                 ToListAsync(cancellationToken: cancellationToken);

            var associado = _map.Map<List<AssociadoResponse>>(entities);
            return associado;
        }
    }
}
