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
    public class OrganizacaoController : ApiController
    {
        private readonly IMediator _mediator;

        public OrganizacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("organizacoes"), AllowAnonymous]        
        // GET: OrganizacaoController
        public async Task<ActionResult<IEnumerable<OrganizacaoResponse>>> GetOrganizacao(bool ativo = true)
        {
            var response = await _mediator.Send(new OrganizacaoQuery(ativo));
            return Ok(response);
        }

        // GET: OrganizacaoController/Details/5
        [HttpGet, Route("details/{id}"), AllowAnonymous]
        public async Task<ActionResult<OrganizacaoResponse>> GetOrganizacaoById(int id)
        {
            var response = await _mediator.Send(new OrganizacaoByIdQuery(id));
            return Ok(response);
        }

        // POST: OrganizacaoController/Create
        [HttpPost, Route("organizacoes"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] OrganizacaoCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // PUT: OrganizacaoController/Edit/5
        [HttpPut, Route("edit"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([FromBody] OrganizacaoUpdateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }

        // DELETE: OrganizacaoController/Delete/5
        [HttpDelete, Route("delete/{id}"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new OrganizacaoDeleteCommand(id));
            return CustomResponse(response);
        }
    }
}
