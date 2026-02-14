using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        public IActionResult AddMovie(Movie newMovie)
        {
            _context.Movies.Add(newMovie);
            _context.SaveChanges();
            
            return View("SubmissionResult", newMovie);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
