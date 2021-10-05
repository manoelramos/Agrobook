namespace Agrobook.Application.Imoveis.Handles
{
    using Agrobook.Application.Imoveis.Queries;
    using Agrobook.Application.Imoveis.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class ImovelByIdQueryHandle : IRequestHandler<ImovelByIdQuery, ImovelResponse>
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IMapper _map;

        public ImovelByIdQueryHandle(IImovelRepository imovelRepository, IMapper map)
        {
            _imovelRepository = imovelRepository;
            _map = map;
        }

        public Task<ImovelResponse> Handle(ImovelByIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = _imovelRepository.
                  Include(c => c.Endereco).
                  FirstOrDefault(x => x.Id.Equals(request.Id));

            var imovel = _map.Map<ImovelResponse>(entitie);

            return Task.FromResult(imovel);
        }
    }
}
