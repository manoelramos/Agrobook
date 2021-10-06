namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.UnidadesMedidas.Commands;
    using Agrobook.Application.UnidadesMedidas.Commmand;
    using Agrobook.Application.UnidadesMedidas.Queries;
    using Agrobook.Application.UnidadesMedidas.Response;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class UnidadesMedidasController : ApiController
    {
        private readonly IMediator _mediator;

        public UnidadesMedidasController(IMediator mediator)
        {
            _mediator = mediator;
        }
             
        /// <summary>
        /// Lista das Unidades de medidas naturais e customizadas(aquelas utilizadas apenas no ambiente do agro negócio)
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>

        [HttpGet, Route("unidades-medidas"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<UnidadeMedidaResponse>>> GetUnidadesMedidas(UnidadesMedidasQuery.TipoFilter filter)
        {
            var response = await _mediator.Send(new UnidadesMedidasQuery(filter));
            return Ok(response);
        }

        /// <summary>
        /// Cria uma unidade de medida customizada com base em uma unidade de medida padrão
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("unidades-medidas"), AllowAnonymous]
        [ProducesResponseType(typeof(UnidadeMedidaResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] UnidadeMedidaCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Atualiza uma unidade de medida customizada
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(UnidadeMedidaResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, Route("unidades-medidas"), AllowAnonymous]
        public async Task<IActionResult> Edit(UnidadeMedidaUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Deleta uma unidade de medida customizada
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("unidades-medidas/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(UnidadeMedidaResponse), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new UnidadeMedidaDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
