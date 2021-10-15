namespace Agrobook.Application.CategoriaDespesa.Handles
{
    using Agrobook.Application.CategoriaDespesa.Queries;
    using Agrobook.Application.CategoriaDespesa.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CategoriaDespesaQueryHandles : IRequestHandler<CategoriaDespesaQuery, List<CategoriaDespesaResponse>>
    {
        private readonly ICategoriaDespesaRepository _repository;
        private readonly IMapper _map;

        public CategoriaDespesaQueryHandles(ICategoriaDespesaRepository repository, IMapper map)
        {
            _repository = repository;
            _map = map;
        }

        public async Task<List<CategoriaDespesaResponse>> Handle(CategoriaDespesaQuery request, CancellationToken cancellationToken)
        {
            var entitie = await _repository.GetAsync(x => x.Ativo, cancellationToken);

            var categorias = _map.Map<List<CategoriaDespesaResponse>>(entitie);

            return categorias;
        }
    }
}
