namespace Agrobook.Api.Controllers.Organizacao
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
    public class OrganizacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("organizacoes"), AllowAnonymous]
        [ProducesResponseType(typeof(IEnumerable<OrganizacaoResponse>), StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        // GET: OrganizacaoController
        public async Task<ActionResult<IEnumerable<OrganizacaoResponse>>> GetOrganizacao()
        {
            var response = await _mediator.Send(new OrganizacaoQuery(true));
            return Ok(response);
        }

        //[HttpGet, Route("organizacao/{id}"), AllowAnonymous]
        //// GET: OrganizacaoController/Details/5
        //public ActionResult GetOrganizacaoById(int id)
        //{
        //    var response = await _mediator.Send();

        //    if (response.HasMessages)
        //        return BadRequest(response.Messages);


        //    return Ok(response.Value);
        //}

        //// GET: OrganizacaoController/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: OrganizacaoController/Create
        [HttpPost, Route("organizacoes"), AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] OrganizacaoCreateCommand command)
        {

            var response = await _mediator.Send(command);

            if (!response.IsValid)
                return BadRequest(response);

            return Ok(response);

        }

        //// GET: OrganizacaoController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: OrganizacaoController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: OrganizacaoController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: OrganizacaoController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
