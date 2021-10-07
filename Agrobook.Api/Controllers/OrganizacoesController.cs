namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Organizacao.Commands;
    using Agrobook.Application.Organizacao.Queries;
    using Agrobook.Application.Organizacao.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    //[Route("api/[controller]"), Authorize(AuthenticationSchemes = "Bearer")]
    [ApiVersion("1")]    
    public class OrganizacoesController : ApiController
    {
        private readonly IMediator _mediator;

        public OrganizacoesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("[controller]"), AllowAnonymous]
        // GET: OrganizacoesController
        public async Task<ActionResult<IEnumerable<OrganizacaoResponse>>> GetOrganizacoes(bool ativo = true)
        {
            var response = await _mediator.Send(new OrganizacaoQuery(ativo));
            return Ok(response);
        }

        // GET: OrganizacoesController/Details/5
        [HttpGet, Route("[controller]/{id}"), AllowAnonymous]
        public async Task<ActionResult<OrganizacaoResponse>> GetOrganizacById(int id)
        {
            var response = await _mediator.Send(new OrganizacaoByIdQuery(id));
            return Ok(response);
        }

        // POST: OrganizacoesController/Create
        [HttpPost, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] OrganizacaoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // PUT: OrganizacoesController/Edit/5
        [HttpPut, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromBody] OrganizacaoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // DELETE: OrganizacoesController/Delete/5
        [HttpDelete, Route("[controller]/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new OrganizacaoDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
