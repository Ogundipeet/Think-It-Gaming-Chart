using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Think_It_Gaming_Chart.Application.Queries;
using Think_It_Gaming_Chart.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Think_It_Gaming_Chart.API.Controllers
{
    [Route("api/games")]
    public class GamesController : Controller
    {
        private readonly IMediator _mediator;
        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("top-games-by-playtime/{minPlaytime?}/{maxPlaytime?}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTopGamesByPlaytime([FromQuery]int? minPlaytime, [FromQuery]int? maxPlaytime)
        {
            var response = await _mediator.Send(new GetTopGamesByPlaytimeQuery(minPlaytime, maxPlaytime));
            return Ok(response);
        }

        [HttpGet("top-games-by-user-id/{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetTopGamesByUserId(int userId)
        {
            var response = await _mediator.Send(new GetTopGamesByUserIdQuery(userId));
            return Ok(response);
        }


    }
}
