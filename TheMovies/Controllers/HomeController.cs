using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheMovies.DAL;
using TheMovies.Models;

namespace TheMovies.Controllers
{
    public class HomeController : Controller
    {
        private TheMoviesDb db = new TheMoviesDb();

        // GET: Home
        public ActionResult Index(string sortOrder)
        {
            if (sortOrder == null) sortOrder = "ascGenre";
            ViewBag.genreOrder = (sortOrder == "ascGenre") ? "descGenre" : "ascGenre";
            ViewBag.dateOrder = (sortOrder == "ascDate") ? "descDate" : "ascDate";

            IQueryable<Movie> movie = db.Movies;
            switch (sortOrder)
            {
                case "descDate":
                    ViewBag.dateOrder = "ascDate";
                    movie = movie.OrderByDescending(c => c.ReleaseDate);
                    break;
                case "descGenre":
                    ViewBag.genreOrder = "ascGenre";
                    movie = movie.OrderByDescending(c => c.Genre);
                    break;
                case "ascDate":
                    ViewBag.dateOrder = "descDate";
                    movie = movie.OrderBy(c => c.ReleaseDate);
                    break;
                case "ascGenre":
                    ViewBag.genreOrder = "descGenre";
                    movie = movie.OrderBy(c => c.Genre);
                    break;
                default:
                    ViewBag.genreOrder = "ascGenre";
                    movie = movie.OrderBy(c => c.Genre);
                    break;
            }
            return View(movie.ToList());
        }

        public PartialViewResult ActorById(int id)
        {
            var act = db.Movies.Find(id);
            @ViewBag.MovieId = id;
            @ViewBag.MovieName = act.MovieTitle;

            return PartialView("_ActorsInFilm", act.Actors);
        }
        public PartialViewResult EditMovie(Movie id)
        {
            var mov = db.Movies.Find(id);
            // db.SaveChanges();
            return PartialView("_EditMovie", mov);
        }


        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create        
        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movie);
        }
        // POST: /Home/CreateActor
        [HttpPost]
        public PartialViewResult CreateActor(Actor incomingActor)
        {

            if (ModelState.IsValid)
            {
                db.Actors.Add(incomingActor);
                db.SaveChanges();
                return ActorById(incomingActor.MovieId);
            }
            return null;
        }

        // GET: Home/Edit/5        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }


        // POST: Home/Edit/5   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            try
            {
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            catch
            {
                return View(movie);
            }


        }

        [HttpPost]
        public HttpStatusCodeResult UpdateActor(Actor actor)
        {
            try
            {
                db.Entry(actor).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
        }


        public ActionResult Delete(int id)
        {
            return View(db.Movies.Find(id));
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Movies.Remove(db.Movies.Find(id));
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost, ActionName("DeleteActor")]
        // This action named 'DeleteConfirmed' to present unique signature
        public PartialViewResult DeleteActor(int id, int MovieId)
        {
            db.Actors.Remove(db.Actors.Find(id));
            db.SaveChanges();
            return PartialView("_ActorsInFilm", db.Movies.Find(MovieId).Actors);
        }


        public PartialViewResult FilmDetails(int id)
        {
            Movie movie = db.Movies.Find(id);

            return PartialView("_FilmDetails", movie);
        }


    }
}
