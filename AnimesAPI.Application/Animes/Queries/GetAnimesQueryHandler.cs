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
    public class GetAnimesQueryHandler : IRequestHandler<GetAnimesQuery, List<Anime>>
    {
        private readonly IAnimeRepository _animeRepository;
        public GetAnimesQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public async Task<List<Anime>> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
        {
            var animes = await _animeRepository.GetAll();

            return animes;
        }
    }
}
