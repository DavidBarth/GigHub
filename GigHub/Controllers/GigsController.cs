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
             
           
                        
            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(),
                //combining date and time into a datetime object for gig's property
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                GenreId = viewModel.Genre,
                Venue = viewModel.Venue
            };


            _context.Gigs.Add(gig);
            _context.SaveChanges();

            //temp redirecting to homepage
            return RedirectToAction("Index", "Home");
        }
    }
}