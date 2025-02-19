using AnimesAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Commands
{
    public class DeleteAnimeCommand : IRequest<Anime>
    {
        public int Id {  get; set; }
    }
}
