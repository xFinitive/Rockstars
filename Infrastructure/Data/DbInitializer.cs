using ApplicationCore.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Infrastructure.Data
{
    public class DbInitializer
    {
        private readonly RockstarsContext _dbContext;

        public DbInitializer(RockstarsContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void SeedData()
        {
            if (!_dbContext.Artists.Any())
            {
                string artistsJSON = File.ReadAllText(@"Files" + Path.DirectorySeparatorChar + "artists.json");
                List<Artist> artistsList = JsonConvert.DeserializeObject<List<Artist>>(artistsJSON);
                _dbContext.Artists.AddRange(artistsList);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Songs.Any())
            {
                string songsJSON = File.ReadAllText(@"Files" + Path.DirectorySeparatorChar + "songs.json");
                List<Song> songsList = JsonConvert.DeserializeObject<List<Song>>(songsJSON);
                _dbContext.Songs.AddRange(songsList);
                _dbContext.SaveChanges();
            }
        }
    }
}
