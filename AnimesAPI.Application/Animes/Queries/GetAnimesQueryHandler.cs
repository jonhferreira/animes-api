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

namespace AnimesAPI.Application.Animes.Queries
{
    public class GetAnimesQueryHandler : IRequestHandler<GetAnimesQuery, ApiResponse<List<Anime>>>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly MessageGet _messageGet;
        private readonly IErrorMessage _errorMessage;
        public GetAnimesQueryHandler(IAnimeRepository animeRepository, MessageGet messageGet, IErrorMessage errorMessage)
        {
            _animeRepository = animeRepository;
            _messageGet = messageGet;
            _errorMessage = errorMessage;
        }

        public async Task<ApiResponse<List<Anime>>> Handle(GetAnimesQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var animes = await _animeRepository.GetAll();

                return new ApiResponse<List<Anime>>(true, HttpStatusCode.OK, animes, _messageGet.Message200Mult("anime"), "");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<Anime>>(false, HttpStatusCode.InternalServerError, null, _errorMessage.ErrorMessage500(), ex.Message);
            }
        }
    }
}

