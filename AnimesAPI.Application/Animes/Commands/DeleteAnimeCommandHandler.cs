using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Commands
{
    public class DeleteAnimeCommandHandler : IRequestHandler<DeleteAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _animeRepository;
        public DeleteAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<Anime> Handle(DeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepository.Delete(request.Id);

            return anime;
        }
    }
}
