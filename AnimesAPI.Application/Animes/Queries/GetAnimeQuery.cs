using AnimesAPI.Application.DTO;
using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Queries
{
    public class GetAnimeQuery : IRequest<ApiResponse<Anime>>
    {  
       public int Id {  get; set; }  
    }
}
