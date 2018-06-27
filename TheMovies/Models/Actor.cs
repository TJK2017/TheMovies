using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TheMovies.Models;

namespace TheMovies.Models
{
    public class Actor
    {
        public int ActorId { get; set; }
        [Display(Name = "Actor First Name")]
        [Required(ErrorMessage = "You Need to Enter An Actor Title ")]
        public string ActorFirstName { get; set; }
        [Display(Name = "Screen Name")]
        [Required(ErrorMessage = "You Need to Enter A ScreenName for the Actor ")]
        public int ScreenNameId { get; set; }
        public string ScreenName { get; set; }
        public int MovieId { get; set; }
        public virtual Movie Movies { get; set; }
    }
}