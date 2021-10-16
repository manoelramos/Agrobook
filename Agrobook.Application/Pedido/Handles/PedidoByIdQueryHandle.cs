namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Pedido.Queries;
    using Agrobook.Application.Pedido.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class PedidoByIdQueryHandle : IRequestHandler<PedidoByIdQuery, PedidoResponse>
    {
        private readonly IPedidoRepository _repository;
        private readonly IMapper _map;

        public PedidoByIdQueryHandle(IPedidoRepository repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<PedidoResponse> Handle(PedidoByIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = _repository                
                .GetByIdAsync(request.Id);                  

            var pedido = _map.Map<PedidoResponse>(entitie);
            return pedido;
        }
    }
}
