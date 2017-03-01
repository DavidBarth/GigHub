using GigHub.Models;
using System.Collections.Generic;

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