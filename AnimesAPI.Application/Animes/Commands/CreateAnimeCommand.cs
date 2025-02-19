using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using MediatR;


namespace AnimesAPI.Application.Animes.Commands
{
    public class CreateAnimeCommand : IRequest<ApiResponse<Anime>>
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
    }
}
