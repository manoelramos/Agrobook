namespace Agrobook.Application.Fazenda.Handles
{
    using Agrobook.Application.Despesa.Queries;
    using Agrobook.Application.Despesa.Response;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DespesasByCategoryQueryHandle : IRequestHandler<DespesasByCategoryQuery, List<DespesaResponse>>
    {
        private readonly IDespesaRepository _despesaRepository;
        private readonly IMapper _map;

        public DespesasByCategoryQueryHandle(IDespesaRepository despesaRepository, IMapper map)
        {
            _despesaRepository = despesaRepository;
            _map = map;
        }

        public Task<List<DespesaResponse>> Handle(DespesasByCategoryQuery request, CancellationToken cancellationToken)
        {
            var entitie = _despesaRepository.
                  Include(c => c.Parcelas).
                  Include(c => c.Patrimonio).
                  Include(c => c.Safra).
                  Include(c => c.CategoriaDespesa).
                  AsNoTracking().
                  FirstOrDefault(x => x.CategoriaDespesaId.Equals(request.categoriaId));

            var despesas = _map.Map<List<DespesaResponse>>(entitie);

            return Task.FromResult(despesas);
        }
    }
}
