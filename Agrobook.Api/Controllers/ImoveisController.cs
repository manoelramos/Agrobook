namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Imoveis.Commands;
    using Agrobook.Application.Imoveis.Queries;
    using Agrobook.Application.Imoveis.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    [Route("[controller]")]
    public class ImoveisController : ApiController
    {
        private readonly IMediator _mediator;

        public ImoveisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista de patrimonio do tipo imóvel
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<IEnumerable<ImovelResponse>>> Get(bool ativo = true)
        {
            var response = await _mediator.Send(new ImovelQuery(ativo));
            return Ok(response);
        }

        /// <summary>
        /// Retorna o patrimonio do tipo imovel pelo ID
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>

        [HttpGet, Route("{id}"), AllowAnonymous]
        public async Task<ActionResult<ImovelResponse>> Get(int id)
        {
            var response = await _mediator.Send(new ImovelByIdQuery(id));
            return Ok(response);
        }

        /// <summary>
        /// Cria um patrimonio do tipo imovel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        [ProducesResponseType(typeof(ImovelResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] ImovelCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        /// <summary>
        /// Atualiza um patrimonio do tipo imóvel
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ImovelResponse), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, AllowAnonymous]
        public async Task<IActionResult> Edit(ImovelUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        ///// <summary>
        ///// Deleta logicamente uma fazenda
        ///// /// </summary>
        ///// <param name = "id" ></ param >
        ///// < returns ></ returns >
        //[HttpDelete, Route("{id}"), AllowAnonymous]
        //[ProducesResponseType(typeof(FazendaResponse), StatusCodes.Status204NoContent)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var response = await _mediator.Send(new FazendaDeleteCommand(id));
        //    return CustomResponse(response);
        //}
    }
}
