using API.Climate.Application.DTOs.Weather.Output;
using API.Climate.Application.Features.Weather;
using API.Climate.Controllers.Base;
using Asp.Versioning;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace API.Climate.Controllers.V1
{
    [ApiController]
    [ApiVersion("1.0")]
    public class WeatherController : BaseController
    {
        public WeatherController(IMediator mediator) : base(mediator) { }

        [HttpGet("{city_id}")]
        [ProducesResponseType(typeof(WeatherDto), StatusCodes.Status200OK)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> GetByCity(
            int city_id,
            [FromQuery(Name = "history")] bool history)
        {

            return Ok(await _mediator.Send(new GetByCityWeather()
            {
                CityId = city_id,
                IncludeHistory = history
            }));

        }
    }
}