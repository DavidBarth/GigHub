using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Linq;
using System.Web.Mvc;


namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs
        [Authorize] //will redirect to log in form
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel
            {
                //get values from context to populate list view
                Genres = _context.Genres.ToList() 
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpPost] //action called only by a POST method
        //convert viewmodel into a gig object add to context and save changes
        public ActionResult Create(GigFormViewModel viewModel)
        {
            //get application user objects from the database
            var artistId = User.Identity.GetUserId();//extracted from lambda expresssion as EF cant translate expression object and cant convert to SQL, value stored in artistId
            var artist = _context.Users.Single(u => u.Id == artistId);//retun an application userr that can be associated with this gig

            //the genre what we have in viewmodel is an integer and that the value of the currently selected option
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            
            var gig = new Gig
            {
                Artist = artist,
                //combining date and time into a datetime object for gig's property
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Genre = genre,
                Venue = viewModel.Venue
            };


            _context.Gigs.Add(gig);
            _context.SaveChanges();

            //temp redirecting to homepage
            return RedirectToAction("Index", "Home");
        }
    }
}