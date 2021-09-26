namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.PessoaFisica.Commands;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class PessoaFisicaController : ApiController
    {
        private readonly IMediator _mediator;

        public PessoaFisicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[HttpGet, Route("pessoafisica"), AllowAnonymous]
        //[ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status200OK)]
        //[ProducesDefaultResponseType]
        //// GET: OrganizacaoController
        //public async Task<ActionResult<IEnumerable<OrganizacaoResponse>>> GetOrganizacao(bool ativo = true)
        //{
        //    var response = await _mediator.Send(new OrganizacaoQuery(ativo));
        //    return Ok(response);
        //}

        //// GET: OrganizacaoController/Details/5
        //[HttpGet, Route("details/{id}"), AllowAnonymous]
        //public async Task<ActionResult<OrganizacaoResponse>> GetOrganizacaoById(int id)
        //{
        //    var response = await _mediator.Send(new OrganizacaoByIdQuery(id));
        //    return Ok(response);
        //}

        // POST: PessoaFisicaController/Create
        [HttpPost, Route("pessoas/fisicas"), AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PessoaFisicaCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }


    }
}
