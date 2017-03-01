using GigHub.Models;
using System.Collections.Generic;

namespace GigHub.ViewModels
{
    // class used to only for presentation
    public class GigFormViewModel
    {
        public string Venue { get; set; }

        //using the following two attributes we can separate 
        //date and time in the view
        public string Date { get; set; }
        public string Time { get; set; }

        //in the dropdown we need the numeric value of the genre
        public int Genre { get; set; }
        //using IEnumerable IF for general simple query for view 
        //to get a list of options of genres in view
        //new SelectList(Model.Genres, "Id", "Name")
        public IEnumerable<Genre> Genres { get; set; }
    }
}