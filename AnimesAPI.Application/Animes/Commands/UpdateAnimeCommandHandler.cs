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
    public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _animeRepository;
        public UpdateAnimeCommandHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }
        public async Task<Anime> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {

            var anime = await _animeRepository.Get(request.Id);

            if (anime is null) 
            {
                throw new InvalidOperationException("Anime not found");
            }

            anime.Name = request.Name;
            anime.Description = request.Description;
            anime.Director = request.Director;
            anime.IsDeleted = request.IsDeleted;


            return await _animeRepository.Update(anime);
        }
    }
}
