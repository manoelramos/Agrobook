namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.DetalhesPatrimonio.Commands;
    using Agrobook.Application.DetalhesPatrimonio.Queries;
    using Agrobook.Application.DetalhesPatrimonio.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class DetalhesPatrimonioController : ApiController
    {
        private readonly IMediator _mediator;

        public DetalhesPatrimonioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista das observações de um patrimônio
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("detalhes-patrimonios/{patrimonioId}"), AllowAnonymous]
        public async Task<ActionResult<DetalhesPatrimonioResponse>> Get(int patrimonioId)
        {
            var response = await _mediator.Send(new DetalhesByPatrimonioIdQuery(patrimonioId));
            return Ok(response);
        }

        /// <summary>
        /// Cria uma observação para o patrimonio especificado 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("detalhes-patrimonios"), AllowAnonymous]
        [ProducesResponseType(typeof(DetalhesPatrimonioResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] DetalhePatrimonioCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }
    }
}
