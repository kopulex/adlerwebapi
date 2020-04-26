using AdlerCatalogueWebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace AdlerCatalogueWebApi.DAL
{
    /// <summary>
    /// SQL data context
    /// </summary>
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> tblMovie { get; set; }

        public MovieDbContext(DbContextOptions<MovieDbContext> options)
            : base(options)
        { }
    }
    
}
