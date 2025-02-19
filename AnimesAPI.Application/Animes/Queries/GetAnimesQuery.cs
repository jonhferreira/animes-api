using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;


namespace AnimesAPI.Application.Animes.Queries
{
    public class GetAnimesQuery : IRequest<ApiResponse<List<Anime>>>
    {
        
    }
}
