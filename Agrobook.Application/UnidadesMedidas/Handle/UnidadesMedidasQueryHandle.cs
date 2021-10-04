namespace Agrobook.Application.UnidadesMedidas.Handles
{
    using Agrobook.Application.UnidadesMedidas.Queries;
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnidadesMedidasQueryHandle : IRequestHandler<UnidadesMedidasQuery, List<UnidadeMedidaResponse>>
    {
        private readonly IUnidadeMedidaBaseRepository _unidadeMedidaBaseRepository;
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;
        private readonly IMapper _map;

        public UnidadesMedidasQueryHandle(IUnidadeMedidaBaseRepository unidadeBase, IUnidadeMedidaRepository unidadeMedidaRepository, IMapper map)
        {
            _unidadeMedidaBaseRepository = unidadeBase;
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _map = map;
        }

        public async Task<List<UnidadeMedidaResponse>> Handle(UnidadesMedidasQuery request, CancellationToken cancellationToken)
        {
            var entitiesBase = _map.Map<List<UnidadeMedidaResponse>>(await _unidadeMedidaBaseRepository.GetAsync(x => x.Ativo == request.Active, cancellationToken));
            var entitiesCustom = _map.Map<List<UnidadeMedidaResponse>>(await _unidadeMedidaRepository.GetAsync(x => x.Ativo == request.Active, cancellationToken));
            var result = entitiesBase.Union(entitiesCustom);

            return result.ToList();
        }
    }
}
