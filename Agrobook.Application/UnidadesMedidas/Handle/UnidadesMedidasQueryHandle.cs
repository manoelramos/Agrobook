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
    using Domain.Models.Base;

    public class UnidadesMedidasQueryHandle : IRequestHandler<UnidadesMedidasQuery, List<UnidadeMedidaResponse>>
    {
        private readonly IUnidadeMedidaRepository _unidadeMedidaRepository;
        private readonly IMapper _map;

        public UnidadesMedidasQueryHandle(IUnidadeMedidaRepository unidadeMedidaRepository, IMapper map)
        {
            _unidadeMedidaRepository = unidadeMedidaRepository;
            _map = map;
        }

        public async Task<List<UnidadeMedidaResponse>> Handle(UnidadesMedidasQuery request, CancellationToken cancellationToken)
        {
            List<UnidadesMedidas> result = request.Filter switch
            {
                UnidadesMedidasQuery.TipoFilter.Base => await _unidadeMedidaRepository.GetAsync(u => u.Ativo && !u.UnidadeBaseId.HasValue, cancellationToken),
                UnidadesMedidasQuery.TipoFilter.Custom => await _unidadeMedidaRepository.GetAsync(u => u.Ativo && u.UnidadeBaseId.HasValue, cancellationToken),
                UnidadesMedidasQuery.TipoFilter.All => await _unidadeMedidaRepository.GetAsync(u => u.Ativo, cancellationToken),
                _ => new(),
            };

            var retorno = _map.Map<List<UnidadeMedidaResponse>>(result);
            return retorno;
        }
    }
}
