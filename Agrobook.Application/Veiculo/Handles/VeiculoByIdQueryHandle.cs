namespace Agrobook.Application.Veiculo.Handles
{
    using Agrobook.Application.Veiculo.Queries;
    using Agrobook.Application.Veiculo.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class VeiculoByIdQueryHandle : IRequestHandler<VeiculoByIdQuery, VeiculoResponse>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IMapper _map;

        public VeiculoByIdQueryHandle(IVeiculoRepository veiculoRepository, IMapper map)
        {
            _veiculoRepository = veiculoRepository;
            _map = map;
        }

        public async Task<VeiculoResponse> Handle(VeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = _veiculoRepository.
                  Include(x => x.Patrimonio.Detalhes).
                  Where(x => x.Id.Equals(request.PatrimonioId)).
                  FirstOrDefault();

            var organizacoes = _map.Map<VeiculoResponse>(entitie);
            return organizacoes;
        }
    }
}
