using ApplicationCore.Models;
using ApplicationCore.Result;
using System.Collections.Generic;

namespace ApplicationCore.Services.Interfaces
{
    public interface ISongService
    {
        OperationResult<IEnumerable<SongDto>> GetAll();
        OperationResult<SongDto> GetById(long id);
        OperationResult<IEnumerable<SongDto>> GetByGenre(string genre);
        OperationResult<IEnumerable<SongDto>> GetBeforeCertainYear(int year);
        OperationResult<SongDto> Add(SongDto songDto);
        OperationResult<SongDto> Update(long id, SongDto songDto);
        OperationResult<SongDto> Delete(long id);
    }
}
