namespace Agrobook.Application.Cultura.Handles
{
    using Agrobook.Application.Cultura.Queries;
    using Agrobook.Application.Cultura.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CulturaQueryHandle : IRequestHandler<CulturasQuery, List<CulturaResponse>>
    {
        private readonly ICulturaRepository _culturaRepository;
        private readonly IMapper _map;

        public CulturaQueryHandle(ICulturaRepository culturaRepository, IMapper map)
        {
            _culturaRepository = culturaRepository;
            _map = map;
        }

        public async Task<List<CulturaResponse>> Handle(CulturasQuery request, CancellationToken cancellationToken)
        {
            var entitie = await _culturaRepository.GetAsync(x => x.Ativo, cancellationToken);

            var culturas = _map.Map<List<CulturaResponse>>(entitie);

            return culturas;
        }
    }
}
