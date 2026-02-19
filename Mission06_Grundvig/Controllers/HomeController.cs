using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission06_Grundvig.Models;
using Mission06_Grundvig.Models.ViewModels;
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
            MovieFormViewModel vm = new MovieFormViewModel
            {
                Movie = new Movie(),
                Categories = _context.Categories.ToList()
            };
            
            return View(vm);
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
            var groupedMovies = _context.Movies
                .Include(m => m.Category)
                .AsEnumerable() // AI says this ensures SQL handles joins, C# handles grouping + dictionary conversion, and avoids weird translation edge cases later.
                .GroupBy(m => m.Category.CategoryName)
                .OrderBy(g => g.Key)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(m => m.Title).ToList()
                );

            return View(groupedMovies);
        }

        [HttpGet]
        public IActionResult EditMovie(int id)
        {
            Movie movieToEdit = _context.Movies
                .Include(m => m.Category)
                .Single(m => m.MovieId == id);

            MovieFormViewModel vm = new MovieFormViewModel
            {
                Movie = movieToEdit,
                Categories = _context.Categories.ToList()
            };
            
            return View("AddMovie", vm);
        }

        [HttpPost]
        public IActionResult EditMovie(int id, Movie editedMovie)
        {
            _context.Update(editedMovie);
            _context.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            return RedirectToAction("ViewMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
