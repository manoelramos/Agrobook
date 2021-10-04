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
    public class PessoasFisicasController : ApiController
    {
        private readonly IMediator _mediator;

        public PessoasFisicasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("pessoas-fisicas"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PessoaFisicaResponse>>> GetPessoaFisica(bool ativo = true)
        {
            var response = await _mediator.Send(new PessoasFisicasQuery(ativo));
            return Ok(response);
        }

        //[HttpGet, Route("{id:min(1)}"), AllowAnonymous]
        [HttpGet, Route("pessoas-fisicas/{id}"), AllowAnonymous]
        public async Task<ActionResult<PessoaFisicaResponse>> GetOrganizacaoById(int id)
        {
            var response = await _mediator.Send(new PessoaFisicaByIdQuery(id));
            return Ok(response);
        }

        [HttpPost, Route("pessoas-fisicas"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<PessoaFisicaResponse>), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PessoaFisicaCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [ProducesResponseType(typeof(IEnumerable<PessoaFisicaResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, Route("pessoas-fisicas"),AllowAnonymous]
        public async Task<IActionResult> Edit(PessoaFisicaUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [HttpDelete, Route("pessoas-fisicas/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<PessoaFisicaResponse>), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new PessoaFisicaDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
