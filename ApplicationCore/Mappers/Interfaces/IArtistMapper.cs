using ApplicationCore.Entities;
using ApplicationCore.Models;
using System.Collections.Generic;

namespace ApplicationCore.Mappers.Interfaces
{
    public interface IArtistMapper
    {
        ArtistDto FromArtist(Artist artist);
        IEnumerable<ArtistDto> FromArtistMany(IEnumerable<Artist> artists);
        Artist FromArtistDto(ArtistDto artistDto);
        IEnumerable<Artist> FromArtistDtoMany(IEnumerable<ArtistDto> artistDtos);
    }
}
