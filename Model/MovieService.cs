using AdlerCatalogueWebApi.DAL;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AdlerCatalogueWebApi.Model
{
    /// <summary>
    /// Interface definition
    /// </summary>
    public interface IMovieService
    {
        void Insert(Movie m);
        int Update(int id, Movie m);
        int Delete(int id);
        Movie GetMovie(int id);
        IEnumerable<Movie> GetMovies();
    }

    /// <summary>
    /// Represents data oprations on Movie table
    /// </summary>
    public class MovieService : IMovieService
    {
        private readonly MovieDbContext _context;

        public MovieService(MovieDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Delete entry
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Returns -1 when not found; 1 when success</returns>
        int IMovieService.Delete(int id)
        {
            var movie = _context.tblMovie.Find(id);
            if (movie == null)
            {
                return -1;
            }

            _context.tblMovie.Remove(movie);
            _context.SaveChangesAsync();

            return 1;
        }

        /// <summary>
        /// Get one movie
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Movie object or NULL</returns>
        Movie IMovieService.GetMovie(int id)
        {
            return _context.tblMovie.Find(id);
        }

        /// <summary>
        /// Get all movies
        /// </summary>
        /// <returns>Returns list of movies</returns>
        IEnumerable<Movie> IMovieService.GetMovies()
        {
            return _context.tblMovie;
        }

        /// <summary>
        /// Add movie
        /// </summary>
        /// <param name="m">Movie object</param>
        void IMovieService.Insert(Movie m)
        {
            _context.tblMovie.Add(m);
            _context.SaveChangesAsync();
        }

        /// <summary>
        /// Update one movie
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <param name="m">Movie object</param>
        /// <returns>Returns -1 when not exists; 1 when success</returns>
        int IMovieService.Update(int id, Movie m)
        {
            _context.Entry(m).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return -1;
                }
                else
                {
                    throw;
                }
            }

            return 1;
        }

        /// <summary>
        /// Check if movie exists
        /// </summary>
        /// <param name="id">Movie ID</param>
        /// <returns>Returns true if exists, false if not.</returns>
        private bool MovieExists(int id)
        {
            return _context.tblMovie.Any(e => e.pkTblMovie == id);
        }
    }
}
