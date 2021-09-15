namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoQueryHandle : IRequestHandler<OrganizacaoQuery, List<OrganizacaoResponse>>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;
        private readonly IMapper _map;

        public OrganizacaoQueryHandle(IOrganizacaoRepository context, IMapper map)
        {
            _organizacaoRepository = context;
            _map = map;
        }

        public async Task<List<OrganizacaoResponse>> Handle(OrganizacaoQuery request, CancellationToken cancellationToken)
        {
            var entities = await _organizacaoRepository.
                Include(c => c.Endereco).
                ToListAsync(cancellationToken: cancellationToken);

            var organizacoes = _map.Map<List<OrganizacaoResponse>>(entities);
            return organizacoes;
        }
    }
}
