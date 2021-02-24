using ApplicationCore.Entities;
using ApplicationCore.Mappers.Interfaces;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Mappers
{
    public class SongMapper : ISongMapper
    {
        private readonly IArtistMapper _artistMapper;
        public SongMapper(IArtistMapper artistMapper)
        {
            _artistMapper = artistMapper;
        }

        public SongDto FromSong(Song song)
        {
            return new SongDto
            {
                Id = song.Id,
                Name = song.Name,
                Year = song.Year,
                Artist = song.Artist,
                Shortname = song.Shortname,
                BPM = song.BPM,
                Duration = song.Duration,
                Genre = song.Genre,
                SpotifyId = song.SpotifyId,
                Album = song.Album
            };
        }

        public IEnumerable<SongDto> FromSongMany(IEnumerable<Song> songs)
        {
            return songs.Select(FromSong).ToList();
        }

        public Song FromSongDto(SongDto songDto)
        {
            return new Song
            {
                Id = songDto.Id,
                Name = songDto.Name,
                Year = songDto.Year,
                Artist = songDto.Artist,
                Shortname = songDto.Shortname,
                BPM = songDto.BPM,
                Duration = songDto.Duration,
                Genre = songDto.Genre,
                SpotifyId = songDto.SpotifyId,
                Album = songDto.Album
            };
        }

        public IEnumerable<Song> FromSongDtoMany(IEnumerable<SongDto> songDtos)
        {
            return songDtos.Select(FromSongDto).ToList();
        }
    }
}
