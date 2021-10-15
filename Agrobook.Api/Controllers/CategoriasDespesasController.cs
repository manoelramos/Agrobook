namespace Agrobook.Api.Controllers
{
    using Agrobook.Application.CategoriaDespesa.Queries;
    using Agrobook.Application.CategoriaDespesa.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [ApiVersion("1")]
    public class CategoriasDespesasController : ApiController
    {
        private readonly IMediator _mediator;

        public CategoriasDespesasController(IMediator mediator)
        {
            _mediator = mediator;
        }


        // <summary>
        /// Lista todas as culturas ativas
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("categorias-despesas"), AllowAnonymous]
        public async Task<ActionResult<IEnumerable<CategoriaDespesaResponse>>> Get()
        {
            var response = await _mediator.Send(new CategoriaDespesaQuery());
            return Ok(response);
        }
    }
}
