using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TheMovies.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Display(Name = "Movie Title")]
        [Required(ErrorMessage = "You Need to Enter A Movie Title ")]
        public string MovieTitle { get; set; }
        [Display(Name = "Release Date"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required(ErrorMessage = "You Need to Enter A Release Date For This Film")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Movie Genre")]
        [Required(ErrorMessage = "You Need to Enter A Movie Genre")]
        public Genre Genre { get; set; }
        public virtual List<Actor> Actors { get; set; }
    }

    public enum Genre
    {
        Action, Adventure, Animation, Comedy, Horror,
    }
}