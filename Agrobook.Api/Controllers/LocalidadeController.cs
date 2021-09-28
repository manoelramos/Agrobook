namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Localidade.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class LocalidadeController : ApiController
    {

        private readonly IMediator _mediator;

        public LocalidadeController(IMediator mediator)
        {
            _mediator = mediator;
        }   

        /// <summary>
        /// Lista completa de estados
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("estados"), AllowAnonymous]
        public async Task<IActionResult> GetEstados()
        {
            var response = await _mediator.Send(new EstadosQuery(33));
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
