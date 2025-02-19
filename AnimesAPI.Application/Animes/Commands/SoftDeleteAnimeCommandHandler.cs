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
    public class SoftDeleteAnimeCommandHandler : IRequestHandler<SoftDeleteAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _animeRepository;
        public SoftDeleteAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }


        public async Task<Anime> Handle(SoftDeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = await _animeRepository.SoftDelete(request.Id);

            return anime;
        }
    }
}
