namespace Agrobook.Application.Fazenda.Handles
{
    using Agrobook.Application.Fazenda.Queries;
    using Agrobook.Application.Fazenda.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class FazendaByIdQueryHandle : IRequestHandler<FazendaByIdQuery, FazendaResponse>
    {
        private readonly IFazendaRepository _fazendaRepository;
        private readonly IMapper _map;

        public FazendaByIdQueryHandle(IFazendaRepository fazendaRepository, IMapper map)
        {
            _fazendaRepository = fazendaRepository;
            _map = map;
        }

        public Task<FazendaResponse> Handle(FazendaByIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = _fazendaRepository.
                  Include(c => c.Endereco).
                  FirstOrDefault(x => x.Id.Equals(request.Id));

            var fazendas = _map.Map<FazendaResponse>(entitie);

            return Task.FromResult(fazendas);
        }
    }
}
