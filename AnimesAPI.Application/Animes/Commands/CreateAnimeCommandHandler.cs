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
    public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, Anime>
    {
        private readonly IAnimeRepository _animeRepository;
        public CreateAnimeCommandHandler(IAnimeRepository animeRepository) 
        {
            _animeRepository = animeRepository;
        }
        public Task<Anime> Handle(CreateAnimeCommand request, CancellationToken cancellationToken)
        {
            var anime = new Anime()
            {
                Name = request.Name,
                Description = request.Description,
                Director= request.Director
            };

            return _animeRepository.Create(anime);

        }
    }
}
