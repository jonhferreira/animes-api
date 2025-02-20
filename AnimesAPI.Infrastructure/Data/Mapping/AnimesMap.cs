using AnimesAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimesAPI.Infrastructure.Data.Mapping
{
    public class AnimesMap : IEntityTypeConfiguration<Anime>
    {
        public void Configure(EntityTypeBuilder<Anime> builder)
        {
            builder.HasKey(a => a.Id).HasName("PK_anime");
            builder.Property(a => a.Name).HasMaxLength(128).IsRequired();
            builder.Property(a => a.Director).HasMaxLength(128).IsRequired();
            builder.Property(a => a.Description).HasMaxLength(256).IsRequired();
            builder.Property(a => a.IsDeleted).IsRequired();
        }
    }


}
