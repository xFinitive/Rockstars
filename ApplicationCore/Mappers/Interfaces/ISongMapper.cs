using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.Mappers.Interfaces
{
    public interface ISongMapper
    {
        SongDto FromSong(Song song);
        IEnumerable<SongDto> FromSongMany(IEnumerable<Song> songs);
        Song FromSongDto(SongDto songDto);
        IEnumerable<Song> FromSongDtoMany(IEnumerable<SongDto> songDtos);
    }
}
