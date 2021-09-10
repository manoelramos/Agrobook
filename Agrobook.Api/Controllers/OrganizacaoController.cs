namespace Agrobook.Api.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using System.Threading.Tasks;
    using Agrobook.Application.Organizacao.Queries;

    //[Route("api/[controller]"), Authorize(AuthenticationSchemes = "Bearer")]
    public class OrganizacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrganizacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet, Route("organizacao"), AllowAnonymous]
        // GET: OrganizacaoController
        public async Task<IActionResult> GetOrganizacao()
        {
            var response = await _mediator.Send(new OrganizacaoQuery(true));

            if (response.HasMessages)
                return BadRequest(response.Messages);


            return Ok(response.Value);
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

        //// POST: OrganizacaoController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
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
