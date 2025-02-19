using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System.Net;


namespace AnimesAPI.Application.Animes.Commands
{
    public class SoftDeleteAnimeCommandHandler : IRequestHandler<SoftDeleteAnimeCommand, ApiResponse<Anime>>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly MessageDelete _deletedMessage;
        private readonly IErrorMessage _errorMessage;
        public SoftDeleteAnimeCommandHandler(IAnimeRepository animeRepository, MessageDelete deletedMessage, IErrorMessage errorMessage)
        {
            _animeRepository = animeRepository;
            _deletedMessage = deletedMessage;
            _errorMessage = errorMessage;
        }


        public async Task<ApiResponse<Anime>> Handle(SoftDeleteAnimeCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var anime = await _animeRepository.SoftDelete(request.Id);

                return new ApiResponse<Anime>(true, HttpStatusCode.OK, anime, _deletedMessage.Message200("anime"), "");
            }
            catch (InvalidOperationException ex)
            {
                return new ApiResponse<Anime>(false, HttpStatusCode.NotFound, null, _errorMessage.ErrorMessage404("animne", "id:", $"{request.Id}"), ex.Message);
            }
            catch (Exception ex)
            {
                return new ApiResponse<Anime>(false, HttpStatusCode.InternalServerError, null, _errorMessage.ErrorMessage500(), ex.Message);
            }
        }
    }
}
