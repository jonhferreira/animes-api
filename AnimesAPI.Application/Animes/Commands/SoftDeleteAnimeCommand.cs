using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using MediatR;

namespace AnimesAPI.Application.Animes.Commands
{
    public class SoftDeleteAnimeCommand : IRequest<ApiResponse<Anime>>
    {
        public int Id { get; set; }
    }
}
