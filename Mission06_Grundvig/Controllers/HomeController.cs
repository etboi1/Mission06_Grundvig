using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Grundvig.Models;
using System.Diagnostics;

namespace Mission06_Grundvig.Controllers
{
    public class HomeController : Controller
    {
        private JoelMovieCollectionContext _context;
        public HomeController (JoelMovieCollectionContext movieContext)
        {
            _context = movieContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MeetJoel()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddMovie()
        {
            ViewBag.Categories = _context.Categories
                .ToList();
            
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            if (!ModelState.IsValid)
            {
                // redisplay the form with errors
                return View();
            }

            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            
            return View("SubmissionResult", newMovie);
        }

        public IActionResult ViewMovies()
        {
            var movies = _context.Movies
                .Include(x => x.Category)
                .OrderBy(x => x.Title).ToList();
            
            return View(movies);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
