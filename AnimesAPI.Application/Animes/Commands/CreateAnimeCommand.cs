using AnimesAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Application.Animes.Commands
{
    public class CreateAnimeCommand : IRequest<Anime>
    {
        public string Name {  get; set; }
        public string Description { get; set; }
        public string Director { get; set; }
    }
}
