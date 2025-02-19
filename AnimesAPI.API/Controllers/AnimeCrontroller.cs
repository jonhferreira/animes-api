using AnimesAPI.Application.Animes.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimesAPI.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AnimeCrontroller : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimeCrontroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAnime(CreateAnimeCommand command)
        {
            var createAnime = await _mediator.Send(command);
            return Ok(createAnime);
        }
    }
}
