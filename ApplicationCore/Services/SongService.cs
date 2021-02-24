using ApplicationCore.Entities;
using ApplicationCore.Mappers.Interfaces;
using ApplicationCore.Models;
using ApplicationCore.Result;
using ApplicationCore.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Services
{
    public class SongService : ISongService
    {
        private readonly IRepository<Song> _repository;
        private readonly ISongMapper _songMapper;

        public SongService(IRepository<Song> repository, ISongMapper songMapper)
        {
            _repository = repository;
            _songMapper = songMapper;
        }

        public OperationResult<IEnumerable<SongDto>> GetAll()
        {
            try
            {
                var songDtos = _songMapper.FromSongMany(_repository.GetAll());

                return OperationResult<IEnumerable<SongDto>>.CreateSuccessResult(songDtos);
            }
            catch (Exception e)
            {
                return OperationResult<IEnumerable<SongDto>>.CreateFailure(e);
            }
        }

        public OperationResult<SongDto> GetById(long id)
        {
            try
            {
                var song = _repository.GetById(id);

                if (song == null)
                {
                    return OperationResult<SongDto>.CreateFailure(new ArgumentNullException());
                }

                var songDto = _songMapper.FromSong(song);

                if (songDto == null)
                {
                    return OperationResult<SongDto>.CreateFailure(new ArgumentNullException());
                }

                return OperationResult<SongDto>.CreateSuccessResult(songDto);
            }
            catch (Exception exception)
            {
                return OperationResult<SongDto>.CreateFailure(exception);
            }
        }

        public OperationResult<IEnumerable<SongDto>> GetByGenre(string genre)
        {
            try
            {
                var songDtos = _songMapper.FromSongMany(_repository.GetAll().Where(song => song.Genre == genre));

                if (songDtos == null)
                {
                    return OperationResult<IEnumerable<SongDto>>.CreateFailure(new ArgumentNullException());
                }

                return OperationResult<IEnumerable<SongDto>>.CreateSuccessResult(songDtos);
            }
            catch (Exception exception)
            {
                return OperationResult<IEnumerable<SongDto>>.CreateFailure(exception);
            }
        }

        public OperationResult<IEnumerable<SongDto>> GetBeforeCertainYear(int year)
        {
            try
            {
                var songDtos = _songMapper.FromSongMany(_repository.GetAll().Where(song => song.Year < year));

                if (songDtos == null)
                {
                    return OperationResult<IEnumerable<SongDto>>.CreateFailure(new ArgumentNullException());
                }

                return OperationResult<IEnumerable<SongDto>>.CreateSuccessResult(songDtos);
            }
            catch (Exception exception)
            {
                return OperationResult<IEnumerable<SongDto>>.CreateFailure(exception);
            }
        }

        public OperationResult<SongDto> Add(SongDto songDto)
        {
            try
            {
                songDto.Id = _repository.Add(_songMapper.FromSongDto(songDto));

                return OperationResult<SongDto>.CreateSuccessResult(songDto);
            }
            catch (Exception exception)
            {
                return OperationResult<SongDto>.CreateFailure(exception);
            }
        }

        public OperationResult<SongDto> Update(long id, SongDto songDto)
        {
            try
            {
                songDto.Id = id;
                _repository.Update(_songMapper.FromSongDto(songDto));

                return OperationResult<SongDto>.CreateSuccessResult(songDto);
            }
            catch (Exception exception)
            {
                return OperationResult<SongDto>.CreateFailure(exception);
            }
        }

        public OperationResult<SongDto> Delete(long id)
        {
            try
            {
                OperationResult<SongDto> songDto = GetById(id);

                if (!songDto.Success)
                {
                    return OperationResult<SongDto>.CreateFailure(songDto.Exception);
                }

                _repository.Delete(_songMapper.FromSongDto(songDto.ResultData));

                return OperationResult<SongDto>.CreateSuccessResult(songDto.ResultData);
            }
            catch (Exception exception)
            {
                return OperationResult<SongDto>.CreateFailure(exception);
            }
        }
    }
}
