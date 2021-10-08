namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Veiculo.Commands;
    using Agrobook.Application.Veiculo.Queries;
    using Agrobook.Application.Veiculo.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    [Route("[controller]")]
    public class VeiculosController : ApiController
    {
        private readonly IMediator _mediator;
        public VeiculosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista de todos os patrimonios do tipo veículos 
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<VeiculoResponse>>> Get(bool ativo = true)
        {
            var response = await _mediator.Send(new VeiculosQuery(ativo));
            return Ok(response);
        }

        /// <summary>
        /// Recupera os dados do patrimonio pelo Id
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>

        [HttpGet, Route("[controller]/{id}"), AllowAnonymous]
        public async Task<ActionResult<VeiculoResponse>> Get(int id)
        {
            var response = await _mediator.Send(new VeiculoByIdQuery(id));
            return Ok(response);
        }

        /// <summary>
        /// Cria um patrimonio do tipo veículo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(VeiculoResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] VeiculoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Atualiza o patrimonio do tipo veículo
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(VeiculoResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, Route("[controller]"), AllowAnonymous]
        public async Task<IActionResult> Edit(VeiculoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Deleta patrimonio do tipo veículo
        /// /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("[controller]/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(VeiculoResponse), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int patrimonioId)
        {
            var response = await _mediator.Send(new VeiculoDeleteCommand(patrimonioId));
            return CustomResponse(response);
        }
    }
}
