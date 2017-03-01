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
        public ActionResult Create(GigFormViewModel viewModel)
        {
            var artistId = User.Identity.GetUserId();
            var artist = _context.Users.Single(u => u.Id == artistId);//retun an application userr that can be associated with this gig
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre.Id);

            var gig = new Gig
            {
                Artist = artist,
                DateTime = DateTime.Parse(string.Format("{0} {1}", viewModel.Date, viewModel.Time)),
                Genre = genre,
                Venue = viewModel.Venue
            };


            _context.Gigs.Add(gig);
            _context.SaveChanges();


            return RedirectToAction("Index", "Home");
        }
    }
}