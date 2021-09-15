namespace Agrobook.Application.Localidade.Handles
{
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EstadosQueryHandle : IRequestHandler<EstadosQuery, List<EstadoResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IEstadosRepository _estadoRepository;

        public EstadosQueryHandle(IMapper mapper, IEstadosRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public async Task<List<EstadoResponse>> Handle(EstadosQuery request, CancellationToken cancellationToken)
        {
            var result = await _estadoRepository.Include().Where(x => x.PaisId.Equals(request.PaisId)).ToListAsync(cancellationToken: cancellationToken);
            return _mapper.Map(result, new List<EstadoResponse>());         
        }
    }
}
