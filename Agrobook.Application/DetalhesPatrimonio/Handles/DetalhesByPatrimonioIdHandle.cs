namespace Agrobook.Application.DetalhesPatrimonio.Handles
{
    using Agrobook.Application.DetalhesPatrimonio.Queries;
    using Agrobook.Application.DetalhesPatrimonio.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class DetalhesByPatrimonioIdHandle : IRequestHandler<DetalhesByPatrimonioIdQuery, List<DetalhesPatrimonioResponse>>
    {
        private readonly IDetalhePatrimonioRepository _detalhePatrimonioRepository;
        private readonly IMapper _map;

        public DetalhesByPatrimonioIdHandle(IDetalhePatrimonioRepository detalhePatrimonioRepository, IMapper map)
        {
            _detalhePatrimonioRepository = detalhePatrimonioRepository;
            _map = map;
        }

        public async Task<List<DetalhesPatrimonioResponse>> Handle(DetalhesByPatrimonioIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = await _detalhePatrimonioRepository.
                GetAsync(x => x.PatrimonioId == request.PatrimonioId, cancellationToken);

            var detalhes = _map.Map<List<DetalhesPatrimonioResponse>>(entitie);
            return detalhes;
        }
    }
}
