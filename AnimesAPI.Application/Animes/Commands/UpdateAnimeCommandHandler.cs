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

namespace AnimesAPI.Application.Animes.Commands
{
    public class UpdateAnimeCommandHandler : IRequestHandler<UpdateAnimeCommand, ApiResponse<Anime>>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly MessageUpdate _updatedMessage;
        private readonly IErrorMessage _errorMessage;
        public UpdateAnimeCommandHandler(IAnimeRepository animeRepository, MessageUpdate updatedMessage, IErrorMessage errorMessage)
        {
            _animeRepository = animeRepository;
            _updatedMessage = updatedMessage;
            _errorMessage = errorMessage;
        }
        public async Task<ApiResponse<Anime>> Handle(UpdateAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var anime = await _animeRepository.Get(request.Id);

                if (anime is null)
                {
                    return new ApiResponse<Anime>(false, HttpStatusCode.NotFound, null, _errorMessage.ErrorMessage404("anime", "id:", $"{request.Id}"), "");
                }

                anime.Name = request.Name;
                anime.Description = request.Description;
                anime.Director = request.Director;
                anime.IsDeleted = request.IsDeleted;

                await _animeRepository.Update(anime);

                return new ApiResponse<Anime>(true, HttpStatusCode.OK, anime, _updatedMessage.Message200("anime"), "");
            }
            catch (ArgumentNullException ex)
            {
                return new ApiResponse<Anime>(false, HttpStatusCode.BadRequest, null, _errorMessage.ErrorMessage409("anime", "Id: ", $"{request.Id}"), ex.Message);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Anime>(false, HttpStatusCode.InternalServerError, null, _errorMessage.ErrorMessage500(), ex.Message);
            }
            
        }
    }
}
