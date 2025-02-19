using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Queries
{
    public class GetAnimeQueryHandler : IRequestHandler<GetAnimeQuery, Anime>
    {
        private readonly IAnimeRepository _animeRepository;
        public GetAnimeQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }



        public async Task<Anime> Handle(GetAnimeQuery request, CancellationToken cancellationToken)
        {
            var animes = await _animeRepository.Get(request.Id);

            return animes;
        }
    }
}
