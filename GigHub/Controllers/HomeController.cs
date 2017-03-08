using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using  GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {

            var upComingGigs = _context.Gigs
                .Include(g => g.Artist)
                .Include(g =>g.Genre)
                .Where(g => g.DateTime > DateTime.Now);


            //using viewmodel to hide action from anonymus users
            var viewModel = new HomeViewModel
            {
                UpcomingGis = upComingGigs,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        
    }
}