namespace Agrobook.Application.Veiculos.Handles
{
    using Agrobook.Application.Veiculos.Queries;
    using Agrobook.Application.Veiculos.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculosQueryHandles : IRequestHandler<VeiculosQuery, List<VeiculoResponse>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _map;

        public VeiculosQueryHandles(IVeiculoRepository veiculoRepository, IMapper map)
        {
            _veiculoRepository = veiculoRepository;
            _map = map;
        }

        public async Task<List<VeiculoResponse>> Handle(VeiculosQuery request, CancellationToken cancellationToken)
        {
            var entite = await _veiculoRepository.GetAsync(x => x.Ativo == request.Ativo, cancellationToken);
            var veiculos = _map.Map<List<VeiculoResponse>>(entite);
            return veiculos;

        }
    }
}
