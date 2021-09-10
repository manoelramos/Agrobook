namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class OrganizacaoQueryHandle : IRequestHandler<OrganizacaoQuery, Response>
    {
        private readonly IOrganizacaoRepository _organizacaoRepository;

        public OrganizacaoQueryHandle(IOrganizacaoRepository context)
        {
            _organizacaoRepository = context;
        }

        public async Task<Response> Handle(OrganizacaoQuery request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var organizacao = await _organizacaoRepository.GetAsync(cancellationToken);
            response.AddValue(organizacao.ToArray());
            return response;
        }
    }
}
