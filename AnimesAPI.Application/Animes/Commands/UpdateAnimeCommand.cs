using AnimesAPI.Domain.Entities;
using MediatR;

namespace AnimesAPI.Application.Animes.Commands
{
    public class UpdateAnimeCommand : IRequest<Anime>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
        public bool IsDeleted { get; set; }
    }
}
