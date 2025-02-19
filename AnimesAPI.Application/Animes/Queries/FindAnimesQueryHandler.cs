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
    public class FindAnimesQueryHandler : IRequestHandler<FindAnimesQuery, List<Anime>>
    {

        private readonly IAnimeRepository _animeRepository;
        public FindAnimesQueryHandler(IAnimeRepository animeRepository)
        {
            _animeRepository = animeRepository;
        }

        public Task<List<Anime>> Handle(FindAnimesQuery request, CancellationToken cancellationToken)
        {
            var animes = _animeRepository.Get(request.Id, request.Director, request.Name);

            return animes;
        }
    }
}
