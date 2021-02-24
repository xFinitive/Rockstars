using ApplicationCore.Models;
using ApplicationCore.Result;
using System.Collections.Generic;

namespace ApplicationCore.Services.Interfaces
{
    public interface IArtistService
    {
        OperationResult<IEnumerable<ArtistDto>> GetAll();
        OperationResult<ArtistDto> GetById(long id);
        OperationResult<ArtistDto> GetByName(string name);
        OperationResult<ArtistDto> Add(ArtistDto artistDto);
        OperationResult<ArtistDto> Update(long id, ArtistDto artistDto);
        OperationResult<ArtistDto> Delete(long id);
    }
}
