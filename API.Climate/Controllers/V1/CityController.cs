using API.Climate.Application.DTOs.City.OutPut;
using API.Climate.Application.Features.Cities;
using API.Climate.Controllers.Base;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Climate.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class CityController : BaseController
    {
        public CityController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        [ProducesResponseType(typeof(List<CityDto>), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> GetCity()
        {
            return Ok(await _mediator.Send(new GetCities()));
        }
    }
}