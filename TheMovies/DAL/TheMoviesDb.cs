using System.Data.Entity;
using TheMovies.Models;

namespace TheMovies.DAL
{
    public class TheMoviesDb : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public TheMoviesDb() : base("MoviesDb")
        { }
    }
}