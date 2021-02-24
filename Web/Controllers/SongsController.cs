using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private readonly ISongService _songService;

        public SongsController(ISongService songService)
        {
            _songService = songService;
        }

        // GET: api/Songs
        [HttpGet]
        public ActionResult<IEnumerable<Song>> GetSongs()
        {
            var result = _songService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.ResultData);
        }

        // GET: api/Songs/5
        [HttpGet("{id}")]
        public ActionResult<Song> GetSong(long id)
        {
            var findResult = _songService.GetById(id);

            if (!findResult.Success)
            {
                if (findResult.Exception is ArgumentOutOfRangeException)
                {
                    return NotFound(findResult);
                }
                else
                {
                    return BadRequest(findResult);
                }
            }
            else
            {
                return Ok(findResult.ResultData);
            }
        }

        // GET: api/Songs/genre
        [HttpGet("genre")]
        public ActionResult<Song> GetSongByGenre(string genre)
        {
            var findResult = _songService.GetByGenre(genre);

            if (!findResult.Success)
            {
                if (findResult.Exception is ArgumentOutOfRangeException)
                {
                    return NotFound(findResult);
                }
                else
                {
                    return BadRequest(findResult);
                }
            }
            else
            {
                return Ok(findResult.ResultData);
            }
        }

        // GET: api/Songs/year
        [HttpGet("year")]
        public ActionResult<Song> GetSongBeforeCertainYear(int year)
        {
            var findResult = _songService.GetBeforeCertainYear(year);

            if (!findResult.Success)
            {
                if (findResult.Exception is ArgumentOutOfRangeException)
                {
                    return NotFound(findResult);
                }
                else
                {
                    return BadRequest(findResult);
                }
            }
            else
            {
                return Ok(findResult.ResultData);
            }
        }

        // PUT: api/Songs/5
        [HttpPut("{id}")]
        public IActionResult PutSong(long id, SongDto songDto)
        {
            if (id != songDto.Id)
            {
                return BadRequest();
            }

            var result = _songService.Update(id, songDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        // POST: api/Songs
        [HttpPost]
        public ActionResult<Song> PostSong(SongDto songDto)
        {
            var result = _songService.Add(songDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction("GetSong", new { id = result.ResultData.Id }, songDto);
        }

        // DELETE: api/Songs/5
        [HttpDelete("{id}")]
        public IActionResult DeleteSong(long id)
        {
            var result = _songService.Delete(id);

            if (!result.Success)
            {
                if (result.Exception is ArgumentOutOfRangeException)
                {
                    return NotFound();
                }
                else
                {
                    return BadRequest(result);
                }
            }
            return NoContent();
        }
    }
}
