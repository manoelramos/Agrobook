namespace Agrobook.Application.PessoaFisica.Handlers
{
    using Agrobook.Application.PessoaFisica.Queries;
    using Agrobook.Application.PessoaFisica.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Threading;
    using System.Threading.Tasks;

    public class PessoaFisicaByIdQueryHandle : IRequestHandler<PessoaFisicaByIdQuery, PessoaFisicaResponse>
    {
        private readonly IAssociadosRepository _associadosRepository;
        private readonly IMapper _map;

        public PessoaFisicaByIdQueryHandle(IAssociadosRepository associadosRepository, IMapper map)
        {
            _associadosRepository = associadosRepository;
            _map = map;
        }

        public async Task<PessoaFisicaResponse> Handle(PessoaFisicaByIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _associadosRepository.
                 Include(e => e.Endereco).
                 Include(c => c.DadosBancarios).
                 Include(c => c.Contatos).
                 Include(d => d.Documentos).
             FirstOrDefaultAsync(x => x.Id == request.Id);

            var associado = _map.Map<PessoaFisicaResponse>(entities);
            return associado;
        }
    }
}
