namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Financiamento.Commands;
    using Agrobook.Application.Financiamento.Queries;
    using Agrobook.Application.Financiamento.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class FinanciamentosController : ApiController
    {
        private readonly IMediator _mediator;

        public FinanciamentosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Relação de financiamento por categoria e ou data de aquisicao
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>

        [HttpGet, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<FinanciamentoResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<FinanciamentoResponse>> Get([FromQuery] FinanciamentoByFiltersQuery request)
        {
            var filters = new FinanciamentoByFiltersQuery(request.CredorId, request.DataInicial, request.DataFinal);
            var response = await _mediator.Send(filters);
            return Ok(response);
        }


        /// <summary>
        /// Adiciona um financiamento e suas parcelas
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(FinanciamentoResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] FinanciamentoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }


        [ProducesResponseType(typeof(FinanciamentoResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, Route("[controller]"), AllowAnonymous]
        public async Task<IActionResult> Edit(FinanciamentoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // DELETE: OrganizacoesController/Delete/5
        [HttpDelete, Route("[controller]/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(FinanciamentoResponse), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new FinanciamentoDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
