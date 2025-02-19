using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Abstractions;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System.Net;


namespace AnimesAPI.Application.Animes.Commands
{
    public class CreateAnimeCommandHandler : IRequestHandler<CreateAnimeCommand, ApiResponse<Anime>>
    {
        private readonly IAnimeRepository _animeRepository;
        private readonly IErrorMessage _errorMessage;
        private readonly ISuccessMessage _successMessage;
        public CreateAnimeCommandHandler(IAnimeRepository animeRepository, IErrorMessage errorMessage, ISuccessMessage successMessage) 
        {
            _animeRepository = animeRepository;
            _errorMessage = errorMessage;
            _successMessage = successMessage;
        }
        public async Task<ApiResponse<Anime>> Handle(CreateAnimeCommand request,  CancellationToken cancellationToken)
        {
            try
            {
                var anime = new Anime()
                {
                    Name = request.Name,
                    Description = request.Description,
                    Director = request.Director
                };

                var animeResponse = await _animeRepository.Create(anime);

                return new ApiResponse<Anime>(true, HttpStatusCode.OK, animeResponse, _successMessage.Message201("anime"), "");
            }
            catch (Exception ex) 
            { 
                return new ApiResponse<Anime>(false, HttpStatusCode.InternalServerError, null, _errorMessage.ErrorMessage500(), ex.Message);
            }
            

        }
    }
}
