namespace Agrobook.Application.UnidadesMedidas.Handles
{
    using Agrobook.Application.UnidadesMedidas.Queries;
    using Agrobook.Application.UnidadesMedidas.Response;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class UnidadesMedidaBaseQueryHandle : IRequestHandler<UnidadesMedidasBaseQuery, List<UnidadeMedidaResponse>>
    {
        private readonly IUnidadeMedidaBaseRepository _unidadeMedidaRepository;
        private readonly IMapper _map;

        public UnidadesMedidaBaseQueryHandle(IUnidadeMedidaBaseRepository context, IMapper map)
        {
            _unidadeMedidaRepository = context;
            _map = map;
        }

        public async Task<List<UnidadeMedidaResponse>> Handle(UnidadesMedidasBaseQuery request, CancellationToken cancellationToken)
        {
            var entities = await _unidadeMedidaRepository.GetAsync(c => c.Ativo == request.Active);

            var unidadesBase = _map.Map<List<UnidadeMedidaResponse>>(entities);
            return unidadesBase;
        }
    }
}
