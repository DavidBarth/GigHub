using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GigHub.ViewModels
{
    public class GigFormViewModel
    {
        public string Venue { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }

        public Genre Genre { get; set; }
        //using IEnumerable IF for general simple query for view
        public IEnumerable<Genre> Genres { get; set; }
    }
}