namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoByIdQueryHandle : IRequestHandler<OrganizacaoByIdQuery, OrganizacaoResponse>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IMapper _map;

        public OrganizacaoByIdQueryHandle(IOrganizacaoRepository organizacaoRepository, IMapper map)
        {
            _organizacaoRepository = organizacaoRepository;
            _map = map;
        }

        public async Task<OrganizacaoResponse> Handle(OrganizacaoByIdQuery request, CancellationToken cancellationToken)
        {
            var entitie = _organizacaoRepository.
                  Include(c => c.Endereco).
                  Where(x => x.Id.Equals(request.Id)).
                  FirstOrDefault();

            var organizacoes = _map.Map<OrganizacaoResponse>(entitie);
            return organizacoes;
        }
    }
}
