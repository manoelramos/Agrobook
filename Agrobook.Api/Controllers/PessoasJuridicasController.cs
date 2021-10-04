namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.PessoaJuridica.Commands;
    using Agrobook.Application.PessoaJuridica.Queries;
    using Agrobook.Application.PessoaJuridica.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class PessoasJuridicasController : ApiController
    {
        private readonly IMediator _mediator;

        public PessoasJuridicasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("pessoas-juridicas"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<PessoaJuridicaResponse>>> GetPessoaFisica(bool ativo = true)
        {
            var response = await _mediator.Send(new PessoasJuridicasQuery(ativo));
            return Ok(response);
        }

        //[HttpGet, Route("{id:min(1)}"), AllowAnonymous]
        [HttpGet, Route("pessoas-juridicas/{id}"), AllowAnonymous]
        public async Task<ActionResult<PessoaJuridicaResponse>> GetOrganizacaoById(int id)
        {
            var response = await _mediator.Send(new PessoaJuridicaByIdQuery(id));
            return Ok(response);
        }

        [HttpPost, Route("pessoas-juridicas"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<PessoaJuridicaResponse>), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] PessoaJuridicaCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [ProducesResponseType(typeof(IEnumerable<PessoaJuridicaResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        [HttpPut, Route("pessoas-juridicas"), AllowAnonymous]
        public async Task<IActionResult> Edit(PessoaJuridicaUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        [HttpDelete, Route("pessoas-juridicas/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<PessoaJuridicaResponse>), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new PessoaJuridicaDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
