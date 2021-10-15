namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Cultura.Queries;
    using Agrobook.Application.Cultura.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class CulturasController : ApiController
    {
        private readonly IMediator _mediator;

        public CulturasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // <summary>
        /// Lista todas as culturas ativas
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CulturaResponse>>> Get()
        {
            var response = await _mediator.Send(new CulturasQuery());
            return Ok(response);
        }
    }
}
