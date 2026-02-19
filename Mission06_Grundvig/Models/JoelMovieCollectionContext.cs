using Microsoft.EntityFrameworkCore;
using Mission06_Grundvig.Utilities;

namespace Mission06_Grundvig.Models
{
    public class JoelMovieCollectionContext : DbContext
    {
        // Override used to store the string from the enum in the db rather than storing an int
        // Also reads the string from the db and converts it into the enum value
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(m => m.Rating)
                .HasConversion(
                    v => v.GetDisplayName(),                       // store "PG-13"
                    v => EnumExtensions.FromDisplayName<Rating>(v) // read back to enum
                );
        }


        public JoelMovieCollectionContext(DbContextOptions<JoelMovieCollectionContext> options) :base (options) { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}