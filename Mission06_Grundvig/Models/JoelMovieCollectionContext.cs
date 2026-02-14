using Microsoft.EntityFrameworkCore;

namespace Mission06_Grundvig.Models
{
    public class JoelMovieCollectionContext : DbContext
    {
        public JoelMovieCollectionContext(DbContextOptions<JoelMovieCollectionContext> options) :base (options) { }

        public DbSet<Movie> Movies { get; set; }
    }
}