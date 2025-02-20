using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AnimesAPI.Application.Animes.Queries
{
    public class FindAnimesQueryHandler : IRequestHandler<FindAnimesQuery, ApiResponse<List<Anime>>>
    {

        private readonly IAnimeRepository _animeRepository;
        private readonly MessageGet _messageGet;
        private readonly IErrorMessage _errorMessage;
        public FindAnimesQueryHandler(IAnimeRepository animeRepository, MessageGet messageGet, IErrorMessage errorMessage)
        {
            _animeRepository = animeRepository;
            _messageGet = messageGet;
            _errorMessage = errorMessage;
        }

        public async Task<ApiResponse<List<Anime>>> Handle(FindAnimesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var animes = await _animeRepository.Get(request.Id, request.Director, request.Name);

                return new ApiResponse<List<Anime>>(true, HttpStatusCode.OK, animes, _messageGet.Message200Mult("anime"), "");
            }

            catch (Exception ex)
            {
                return new ApiResponse<List<Anime>>(false, HttpStatusCode.InternalServerError, null, _errorMessage.ErrorMessage500(), ex.Message);
            }
        }
    }
}
