namespace Agrobook.Application.Imoveis.Handles
{
    using Agrobook.Application.Imoveis.Queries;
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ImoveisQueryHandle : IRequestHandler<ImovelQuery, List<ImovelResponse>>
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IMapper _map;

        public ImoveisQueryHandle(IImovelRepository imovelRepository, IMapper map)
        {
            _imovelRepository = imovelRepository;
            _map = map;
        }

        public async Task<List<ImovelResponse>> Handle(ImovelQuery request, CancellationToken cancellationToken)
        {
            var entities = await _imovelRepository.
                Include(c => c.Endereco).
                Where(x => x.Ativo == request.Ativo).
                ToListAsync(cancellationToken: cancellationToken);

            var imoveis = _map.Map<List<ImovelResponse>>(entities);
            return imoveis;
        }
    }
}
