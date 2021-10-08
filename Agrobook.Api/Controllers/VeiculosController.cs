namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Veiculos.Queries;
    using Agrobook.Application.Veiculos.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
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

        ///// <summary>
        ///// Lista das Unidades de medidas naturais e customizadas(aquelas utilizadas apenas no ambiente do agro negócio)
        ///// </summary>
        ///// <param name="ativo"></param>
        ///// <returns></returns>

        //[HttpGet, Route("[controller]/{id}"), AllowAnonymous]
        //public async Task<ActionResult<FazendaResponse>> Get(int id)
        //{
        //    var response = await _mediator.Send(new FazendaByIdQuery(id));
        //    return Ok(response);
        //}

        ///// <summary>
        ///// Cria uma unidade de medida customizada com base em uma unidade de medida padrão
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[HttpPost, Route("[controller]"), AllowAnonymous]
        //[ProducesResponseType(typeof(FazendaResponse), StatusCodes.Status201Created)]
        //[ProducesDefaultResponseType]
        ////[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([FromBody] FazendaCreateCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return CustomResponse(response);
        //}

        ///// <summary>
        ///// Atualiza os dados de uma fazenda
        ///// </summary>
        ///// <param name="command"></param>
        ///// <returns></returns>
        //[ProducesResponseType(typeof(FazendaResponse), StatusCodes.Status200OK)]
        //[ProducesDefaultResponseType]
        //[HttpPut, Route("[controller]"), AllowAnonymous]
        //public async Task<IActionResult> Edit(FazendaUpdateCommand command)
        //{
        //    var response = await _mediator.Send(command);
        //    return CustomResponse(response);
        //}

        ///// <summary>
        ///// Deleta logicamente uma fazenda
        ///// /// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //[HttpDelete, Route("[controller]/{id}"), AllowAnonymous]
        //[ProducesResponseType(typeof(FazendaResponse), StatusCodes.Status204NoContent)]
        //[ProducesDefaultResponseType]
        //public async Task<ActionResult> Delete(int id)
        //{
        //    var response = await _mediator.Send(new FazendaDeleteCommand(id));
        //    return CustomResponse(response);
        //}
    }
}
