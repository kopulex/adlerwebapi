using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdlerCatalogueWebApi.Model;
using Microsoft.AspNetCore.Authorization;

namespace AdlerCatalogueWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _movieService.GetMovies();
        }

        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = await Task.Run(() => _movieService.GetMovie(id));
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }

        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie([FromRoute] int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != movie.pkTblMovie)
            {
                return BadRequest();
            }

            try
            {
                var ret = await Task.Run(() => _movieService.Update(id, movie));
                if (ret == -1)
                {
                    return NotFound();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return NoContent();
        }

        // POST: api/Movies
        [HttpPost]
        public async Task<IActionResult> PostMovie([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await Task.Run(() => _movieService.Insert(movie));

            return CreatedAtAction("GetMovie", new { id = movie.pkTblMovie }, movie);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ret = await Task.Run(() => _movieService.Delete(id));
            if (ret == -1)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}