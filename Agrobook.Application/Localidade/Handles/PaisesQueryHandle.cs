namespace Agrobook.Application.Localidade.Handles
{
    using Agrobook.Application.Localidade.Queries;
    using Agrobook.Application.Localidade.Responses;
    using Agrobook.Domain.Interfaces.Data;
    using AutoMapper;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class PaisesQueryHandle : IRequestHandler<PaisesQuery, List<PaisResponse>>
    {
        private readonly IPaisesRepository _paisesRepository;
        private readonly IMapper _mapper;

        public PaisesQueryHandle(IPaisesRepository paisesRepository, IMapper mapper)
        {
            _paisesRepository = paisesRepository;
            _mapper = mapper;
        }

        public async Task<List<PaisResponse>> Handle(PaisesQuery request, CancellationToken cancellationToken)
        {            
            var result = await _paisesRepository.GetAsync(cancellationToken);                     
            return _mapper.Map(result, new List<PaisResponse>());            
        }
    }
}
