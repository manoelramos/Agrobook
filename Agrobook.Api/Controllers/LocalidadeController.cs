namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Localidade.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class LocalidadeController : ControllerBase
    {

        private readonly IMediator _mediator;

        public LocalidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista completa de paises
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("paises"), AllowAnonymous]
        public async Task<IActionResult> GetPaises()
        {
            var response = await _mediator.Send(new PaisesQuery(true));
            return Ok(response);
        }

        /// <summary>
        /// Lista completa de estados
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("estados/{paisId}"), AllowAnonymous]
        public async Task<IActionResult> GetEstados(int paisId)
        {
            var response = await _mediator.Send(new EstadosQuery(paisId));
            return Ok(response);
        }

        ///// <summary>
        ///// Lista completa de cidades por estado
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet, Route("cidades"), AllowAnonymous]
        //public async Task<IActionResult> GetPaises()
        //{
        //    var response = await _mediator.Send(new CidadesQuery(true));

        //    if (response.HasMessages)
        //        return BadRequest(response.Messages);


        //    return Ok(response.Value);

        //}

    }
}
