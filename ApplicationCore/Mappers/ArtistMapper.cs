using ApplicationCore.Entities;
using ApplicationCore.Mappers.Interfaces;
using ApplicationCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Mappers
{
    public class ArtistMapper : IArtistMapper
    {
        public ArtistDto FromArtist(Artist artist)
        {
            return new ArtistDto
            {
                Id = artist.Id,
                Name = artist.Name
            };
        }

        public IEnumerable<ArtistDto> FromArtistMany(IEnumerable<Artist> artists)
        {
            return artists.Select(FromArtist).ToList();
        }

        public Artist FromArtistDto(ArtistDto artistDto)
        {
            return new Artist
            {
                Id = artistDto.Id,
                Name = artistDto.Name
            };
        }

        public IEnumerable<Artist> FromArtistDtoMany(IEnumerable<ArtistDto> artistDtos)
        {
            return artistDtos.Select(FromArtistDto).ToList();
        }
    }
}
