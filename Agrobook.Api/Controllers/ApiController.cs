﻿namespace Agrobook.Api.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using Agrobook.Domain.Core.Responses;
    using FluentValidation.Results;
    //using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    //[Authorize]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Consumes("application/json")]
    public abstract class ApiController : ControllerBase
    {
        private readonly List<string> _errors = new List<string>();
        protected readonly string _verbs = "GET,OPTIONS,POST,PUT,DELETE";

        [HttpOptions]
        public IActionResult Options()
        {
            Response.Headers.Add("Allow", _verbs);
            return Ok();
        }

        protected ActionResult CustomResponse(object result = default)
        {
            if (IsOperationValid())
            {
                if (HttpContext.Request.Method == "DELETE")
                    return NoContent();

                return Ok(result);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                AddError(error.ErrorMessage);

            return CustomResponse();
        }

        protected ActionResult CustomResponse<TResponse>(Response<TResponse> response)
        {
            foreach (var error in response.ValidationResult.Errors)
                AddError(error.ErrorMessage);

            return CustomResponse(response.Data);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
