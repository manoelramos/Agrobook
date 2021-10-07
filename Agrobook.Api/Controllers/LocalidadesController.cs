namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Localidade.Queries;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class LocalidadesController : ApiController
    {
        private readonly IMediator _mediator;

        public LocalidadesController(IMediator mediator)
        {
            _mediator = mediator;
        }   

        /// <summary>
        /// Lista completa de estados
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("[controller]"), AllowAnonymous]
        public async Task<IActionResult> GetEstados()
        {
            var response = await _mediator.Send(new EstadosQuery(33));
            return Ok(response);
        }        
    }
}
