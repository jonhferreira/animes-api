using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using AnimesAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Infrastructure.Repository
{
    public class AnimeRepository : BaseRepository<Anime>, IAnimeRepository
    {
        private readonly AnimesDBContext _animeDbContext;
        public AnimeRepository(AnimesDBContext context) : base(context)
        {
            _animeDbContext = context;
        }

        public async Task<List<Anime>> Get(int id, string director, string name)
        {
            var animes = await _animeDbContext.Animes.Where(a => a.Id == id || a.Director == director || a.Name == name).ToListAsync();

            return animes;
        }

        public async Task SoftDelete(int id)
        {
            var anime = await _animeDbContext.Animes.FindAsync(id);
            
            anime.IsDeleted = true;

            _animeDbContext.SaveChanges

        }
    }
}
