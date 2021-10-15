namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.Despesa.Commands;
    using Agrobook.Application.Despesa.Queries;
    using Agrobook.Application.Despesa.Response;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]    
    public class DespesasController : ApiController
    {
        private readonly IMediator _mediator;

        public DespesasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Lista de despesas por categoria
        /// </summary>
        /// <param name="ativo"></param>
        /// <returns></returns>
        [HttpGet, Route("[controller]"), AllowAnonymous]
        public async Task<ActionResult<List<DespesaResponse>>> Get(int categoriaId)
        {
            var response = await _mediator.Send(new DespesasByCategoryQuery(categoriaId));
            return Ok(response);
        }

        /// <summary>
        /// Cria uma despesa 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost, Route("[controller]"), AllowAnonymous]
        [ProducesResponseType(typeof(DespesaResponse), StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] DespesaCreateCommand command)
        {
            var response = await _mediator.Send(command);
            return CustomResponse(response);
        }
    }
}
