namespace Agrobook.Application.Fazenda.Handles
{
    using Agrobook.Application.Fazenda.Queries;
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class FazendasQueryHandle : IRequestHandler<FazendaQuery, List<FazendaResponse>>
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IMapper _map;

        public FazendasQueryHandle(IFazendaRepository context, IMapper map)
        {
            _fazendaRepository = context;
            _map = map;
        }

        public async Task<List<FazendaResponse>> Handle(FazendaQuery request, CancellationToken cancellationToken)
        {
            var entities = await _fazendaRepository.
                Include(c => c.Endereco).
                Where(x => x.Ativo == request.Ativo).
                ToListAsync(cancellationToken: cancellationToken);

            var fazendas = _map.Map<List<FazendaResponse>>(entities);
            return fazendas;
        }
    }
}
