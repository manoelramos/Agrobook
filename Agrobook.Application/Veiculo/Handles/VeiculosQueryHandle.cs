namespace Agrobook.Application.Veiculo.Handles
{
    using Agrobook.Application.Veiculo.Queries;
    using Agrobook.Application.Veiculo.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculosQueryHandle : IRequestHandler<VeiculosQuery, List<VeiculoResponse>>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _map;

        public VeiculosQueryHandle(IVeiculoRepository veiculoRepository, IMapper map)
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
