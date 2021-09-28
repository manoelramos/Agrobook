namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.PessoaFisica.Commands;
    using Agrobook.Application.PessoaFisica.Queries;
    using Agrobook.Application.PessoaFisica.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class PessoaFisicaController : ApiController
    {
        private readonly IMediator _mediator;

        public PessoaFisicaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("pessoafisica"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AssociadoResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        // GET: PessoaFisicaController
        public async Task<ActionResult<IEnumerable<AssociadoResponse>>> GetPessoaFisica(bool ativo = true)
        {
            var response = await _mediator.Send(new PessoaFisicaQuery(ativo));
            return Ok(response);
        }

        //// GET: OrganizacaoController/Details/5
        //[HttpGet, Route("details/{id}"), AllowAnonymous]
        //public async Task<ActionResult<OrganizacaoResponse>> GetOrganizacaoById(int id)
        //{
        //    var response = await _mediator.Send(new OrganizacaoByIdQuery(id));
        //    return Ok(response);
        //}

        // POST: PessoaFisicaController/Create
        [HttpPost, Route("pessoas/fisicas"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<AssociadoResponse>), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] AssociadoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }


    }
}
