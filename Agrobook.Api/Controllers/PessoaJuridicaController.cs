namespace Agrobook.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    public class PessoaJuridicaController : ApiController
    {
        private readonly IMediator _mediator;

        public PessoaJuridicaController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
