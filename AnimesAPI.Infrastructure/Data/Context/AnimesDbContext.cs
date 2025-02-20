using System;
using AnimesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;



namespace AnimesAPI.Infrastructure.Data.Context;

public class AnimesDBContext : DbContext
{
    public AnimesDBContext(DbContextOptions<AnimesDBContext> options) : base(options) {    
    }

    public DbSet<Anime> Animes { get; set; }
}
