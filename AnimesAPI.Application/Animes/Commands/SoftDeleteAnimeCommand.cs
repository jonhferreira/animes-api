using AnimesAPI.Domain.Entities;
using MediatR;

namespace AnimesAPI.Application.Animes.Commands
{
    public class SoftDeleteAnimeCommand : IRequest<Anime>
    {
        public int Id { get; set; }
    }
}
