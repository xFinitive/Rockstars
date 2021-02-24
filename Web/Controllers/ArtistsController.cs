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
    public class ArtistsController : ControllerBase
    {
        private readonly IArtistService _artistService;

        public ArtistsController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        // GET: api/Artists
        [HttpGet]
        public ActionResult<IEnumerable<Artist>> GetArtists()
        {
            var result = _artistService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result.ResultData);
        }

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public ActionResult<Artist> GetArtist(long id)
        {
            var findResult = _artistService.GetById(id);

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

        // GET: api/Artists/name
        [HttpGet("name")]
        public ActionResult<Artist> GetArtistByName(string name)
        {
            var findResult = _artistService.GetByName(name);

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

        // PUT: api/Artists/5
        [HttpPut("{id}")]
        public IActionResult PutArtist(long id, ArtistDto artistDto)
        {
            if (id != artistDto.Id)
            {
                return BadRequest();
            }

            var result = _artistService.Update(id, artistDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return NoContent();
        }

        // POST: api/Artists
        [HttpPost]
        public ActionResult<Artist> PostArtist(ArtistDto artistDto)
        {
            var result = _artistService.Add(artistDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return CreatedAtAction("GetArtist", new { id = result.ResultData.Id }, artistDto);
        }

        // DELETE: api/Artists/5
        [HttpDelete("{id}")]
        public IActionResult DeleteArtist(long id)
        {
            var result = _artistService.Delete(id);

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
