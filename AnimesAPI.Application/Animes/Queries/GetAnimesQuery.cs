using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;


namespace AnimesAPI.Application.Animes.Queries
{
    public class GetAnimesQuery : IRequest<List<Anime>>
    {
        
    }
}
