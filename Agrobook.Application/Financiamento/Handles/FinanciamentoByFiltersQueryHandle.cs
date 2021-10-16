namespace Agrobook.Application.Organizacao.Handles
{
    using Agrobook.Application.Financiamento.Queries;
    using Agrobook.Application.Financiamento.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class FinanciamentoByFiltersQueryHandle : IRequestHandler<FinanciamentoByFiltersQuery, List<FinanciamentoResponse>>
    {
        private readonly IFinanciamentoRepository _repository;
        private readonly IMapper _map;

        public FinanciamentoByFiltersQueryHandle(IFinanciamentoRepository repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        public Task<List<FinanciamentoResponse>> Handle(FinanciamentoByFiltersQuery request, CancellationToken cancellationToken)
        {
            var query = _repository.GetQueryble(x => x.Ativo);
            
            if(!request.CredorId.Equals(0))
                query.Where(x => x.CredorId == request.CredorId);

            if (!request.DataInicial.Equals(0) && !request.DataFinal.Equals(0))
                query.Where(x => x.AdquiridoEm > request.DataInicial && x.AdquiridoEm < request.DataFinal);

            var entitie = query.ToList();

            var financiamentos = _map.Map<List<FinanciamentoResponse>>(entitie);
            return Task.FromResult(financiamentos);
        }
    }
}
