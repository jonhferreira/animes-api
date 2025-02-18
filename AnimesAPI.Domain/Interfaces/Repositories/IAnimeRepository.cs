using AnimesAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Domain.Interfaces.Repositories
{
    public interface IAnimeRepository : IBaseRepository<Anime>
    {
        Task SoftDelete(int id);
        Task<List<Anime>> Get(int id, string director, string name);
    }
}
