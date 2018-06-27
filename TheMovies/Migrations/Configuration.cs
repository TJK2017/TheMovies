namespace TheMovies.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TheMovies.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TheMovies.DAL.TheMoviesDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TheMovies.DAL.TheMoviesDb context)
        {
            var moviegroup = new List<Movie>
            {
                // neatly nested object creation
                new Movie() { MovieTitle="Jurassic World: Fallen Kingdom", ReleaseDate=DateTime.Parse("06/06/18"), Genre=Genre.Action, Actors = new List<Actor> {
                    new Actor { ActorFirstName= "Chris Pratt", ScreenName="Owen" },
                    new Actor { ActorFirstName= "Bryce Dallas Howard", ScreenName="Claire" }
                } },
                 new Movie() { MovieTitle="Oceans 8", ReleaseDate = DateTime.Parse("22/06/18"), Genre=Genre.Comedy, Actors = new List<Actor> {
                    new Actor { ActorFirstName= "Sandra Bullock",ScreenName="Debbie" },
                    new Actor { ActorFirstName= "Cate Blanchett", ScreenName="Lou" }
                } },
                  new Movie() { MovieTitle="Hereditary", ReleaseDate= DateTime.Parse("15/06/18"), Genre=Genre.Horror, Actors = new List<Actor> {
                    new Actor { ActorFirstName= "Toni Collette",ScreenName="Annie" },
                    new Actor { ActorFirstName= "Gabriel Byrne", ScreenName="Steve" }
                } },
                   new Movie() { MovieTitle="Deadpool 2", ReleaseDate = DateTime.Parse("16/05/18"), Genre=Genre.Comedy, Actors = new List<Actor> {
                    new Actor { ActorFirstName= "Ryan Reynolds",ScreenName="Deadpool" },
                    new Actor { ActorFirstName= "Josh Brolin", ScreenName="Cable" }
                } },
                    new Movie() { MovieTitle="Avengers: Infinity War", ReleaseDate = DateTime.Parse("26/04/18"), Genre=Genre.Animation, Actors = new List<Actor> {
                    new Actor { ActorFirstName= "Robert Downey Jr",ScreenName="IronMan" },
                    new Actor { ActorFirstName= "Chris Hemsworth", ScreenName="Thor" }
                } },

            };
            moviegroup.ForEach(m => context.Movies.Add(m));
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
