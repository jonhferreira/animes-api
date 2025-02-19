using AnimesAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Queries
{
    public class FindAnimesQuery:IRequest<List<Anime>>
    {
        
        public int? Id {  get; set; }
        public string? Name {  get; set; }
        public string? Director { get; set; }
    }
}
