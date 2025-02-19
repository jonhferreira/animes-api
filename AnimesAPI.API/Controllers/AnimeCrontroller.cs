using AnimesAPI.Application.Animes.Commands;
using AnimesAPI.Application.Animes.Queries;
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

        [HttpPut]
        public async Task<IActionResult> UpdateAnime(UpdateAnimeCommand commad)
        {
            var anime = await _mediator.Send(commad);
            return Ok(anime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            var command = new DeleteAnimeCommand { Id = id };

            var anime = await _mediator.Send(command);
            return Ok(anime);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> SoftDeleteAnime(int id)
        {
            var command = new SoftDeleteAnimeCommand { Id = id };

            var anime = await _mediator.Send(command);
            return Ok(anime);
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimes()
        {
            var query = new GetAnimesQuery();
            var animes = await _mediator.Send(query);

            return Ok(animes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var query = new GetAnimeQuery() { Id = id};
            var anime = await _mediator.Send(query);

            return Ok(anime);
        }

        [HttpGet]
        public async Task<IActionResult> find(int? id, string? name, string? director)
        {
            var query = new FindAnimesQuery() { Id=id, Name=name, Director=director };
            var anime = await _mediator.Send(query);

            return Ok(anime);
        }


    }
}
