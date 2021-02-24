using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class RockstarsContext : DbContext
    {
        public RockstarsContext(DbContextOptions<RockstarsContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<Artist>()
                .HasIndex(artist => artist.Name).IsUnique();

            modelBuilder.Entity<Song>()
               .HasIndex(song => song.SpotifyId).IsUnique();
        }
    }
}
