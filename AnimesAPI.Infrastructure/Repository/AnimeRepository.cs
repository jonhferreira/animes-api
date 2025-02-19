using AnimesAPI.Domain.Entities;
using AnimesAPI.Domain.Interfaces.Repositories;
using AnimesAPI.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

            if (animes.Count <= 0)
            {
                throw new InvalidOperationException("Anime not found");
            }

            return animes;
        }

        public async Task<Anime> SoftDelete(int id)
        {
            var anime = await _animeDbContext.Animes.FindAsync(id);
            
            if(anime is null)
            {
                throw new InvalidOperationException("Anime not found");
            }

            anime.IsDeleted = true;
            await _animeDbContext.SaveChangesAsync();

            return anime;

        }
    }
}
