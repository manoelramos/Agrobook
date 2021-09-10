namespace Agrobook.Application.Localidade.Handles
{
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Domain.Core.Messaging;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class EstadosQueryHandle : IRequestHandler<EstadosQuery, Response>
    {
        private readonly IMapper _mapper;
        private readonly IEstadosRepository _estadoRepository;

        public EstadosQueryHandle(IMapper mapper, IEstadosRepository estadoRepository)
        {
            _mapper = mapper;
            _estadoRepository = estadoRepository;
        }

        public async Task<Response> Handle(EstadosQuery request, CancellationToken cancellationToken)
        {
            var response = new Response();
            var result = await _estadoRepository.Include().Where(x => x.PaisId.Equals(request.PaisId)).ToListAsync();
            var estados = _mapper.Map(result, new List<EstadoResponse>());
            response.AddValue(estados);
            return response;
        }
    }
}
