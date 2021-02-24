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
    public class ArtistService : IArtistService
    {
        private readonly IRepository<Artist> _repository;
        private readonly IArtistMapper _artistMapper;

        public ArtistService(IRepository<Artist> repository, IArtistMapper artistMapper)
        {
            _repository = repository;
            _artistMapper = artistMapper;
        }

        public OperationResult<IEnumerable<ArtistDto>> GetAll()
        {
            try
            {
                var artistDtos = _artistMapper.FromArtistMany(_repository.GetAll());

                return OperationResult<IEnumerable<ArtistDto>>.CreateSuccessResult(artistDtos);
            }
            catch (Exception e)
            {
                return OperationResult<IEnumerable<ArtistDto>>.CreateFailure(e);
            }
        }

        public OperationResult<ArtistDto> GetById(long id)
        {
            try
            {
                var artist = _repository.GetById(id);

                if (artist == null)
                {
                    return OperationResult<ArtistDto>.CreateFailure(new ArgumentNullException());
                }

                var artistDto = _artistMapper.FromArtist(artist);

                if (artistDto == null)
                {
                    return OperationResult<ArtistDto>.CreateFailure(new ArgumentNullException());
                }

                return OperationResult<ArtistDto>.CreateSuccessResult(artistDto);
            }
            catch (Exception exception)
            {
                return OperationResult<ArtistDto>.CreateFailure(exception);
            }
        }

        public OperationResult<ArtistDto> GetByName(string name)
        {
            try
            {
                var artist = _repository.GetAll().FirstOrDefault(artist => artist.Name == name);

                if (artist == null)
                {
                    return OperationResult<ArtistDto>.CreateFailure(new ArgumentNullException());
                }

                var artistDto = _artistMapper.FromArtist(artist);

                if (artistDto == null)
                {
                    return OperationResult<ArtistDto>.CreateFailure(new ArgumentNullException());
                }

                return OperationResult<ArtistDto>.CreateSuccessResult(artistDto);
            }
            catch (Exception exception)
            {
                return OperationResult<ArtistDto>.CreateFailure(exception);
            }
        }

        public OperationResult<ArtistDto> Add(ArtistDto artistDto)
        {
            try
            {
                var existingArtist = _repository.GetAll().Any(artist => artist.Name == artistDto.Name);

                if (existingArtist)
                {
                    return OperationResult<ArtistDto>.CreateFailure(new Exception("Artist with name " + artistDto.Name + " already exists and has to be unique"));
                }

                artistDto.Id = _repository.Add(_artistMapper.FromArtistDto(artistDto));

                return OperationResult<ArtistDto>.CreateSuccessResult(artistDto);
            }
            catch (Exception exception)
            {
                return OperationResult<ArtistDto>.CreateFailure(exception);
            }
        }

        public OperationResult<ArtistDto> Update(long id, ArtistDto artistDto)
        {
            try
            {
                artistDto.Id = id;
                _repository.Update(_artistMapper.FromArtistDto(artistDto));

                return OperationResult<ArtistDto>.CreateSuccessResult(artistDto);
            }
            catch (Exception exception)
            {
                return OperationResult<ArtistDto>.CreateFailure(exception);
            }
        }

        public OperationResult<ArtistDto> Delete(long id)
        {
            try
            {
                OperationResult<ArtistDto> artistDto = GetById(id);

                if (!artistDto.Success)
                {
                    return OperationResult<ArtistDto>.CreateFailure(artistDto.Exception);
                }

                _repository.Delete(_artistMapper.FromArtistDto(artistDto.ResultData));

                return OperationResult<ArtistDto>.CreateSuccessResult(artistDto.ResultData);
            }
            catch (Exception exception)
            {
                return OperationResult<ArtistDto>.CreateFailure(exception);
            }
        }
    }
}
