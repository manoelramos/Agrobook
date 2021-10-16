namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Pedido.Commands;
    using Agrobook.Application.Pedido.Queries;
    using Agrobook.Application.Pedido.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class PedidosController : ApiController
    {
        private readonly IMediator _mediator;

        public PedidosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna os detalhes do pedido 
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>

        [HttpGet, Route("[controller]/{id}"), AllowAnonymous]
        public async Task<ActionResult<PedidoResponse>> Get(int id)
        {
            var response = await _mediator.Send(new PedidoByIdQuery(id));
            return Ok(response);
        }

        // POST: OrganizacoesController/Create
        [HttpPost, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(PedidoResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PedidoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // PUT: OrganizacoesController/Edit/5
        [HttpPut, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(PedidoResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromBody] PedidoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // DELETE: OrganizacoesController/Delete/5
        [HttpDelete, Route("[controller]/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(PedidoResponse), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new PedidoDeleteCommand(id));
            return CustomResponse(response);
        }

    }
}
