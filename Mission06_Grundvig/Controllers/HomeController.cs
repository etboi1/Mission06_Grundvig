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
        public IActionResult AddMovie(MovieFormViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        Console.WriteLine($"{entry.Key}: {error.ErrorMessage}");
                    }
                }

                // redisplay the form with errors
                vm.Categories = _context.Categories.ToList();
                return View(vm);
            }

            _context.Movies.Add(vm.Movie);
            _context.SaveChanges();
            
            return View("SubmissionResult", vm.Movie);
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
        public IActionResult EditMovie(MovieFormViewModel vm)
        {
            Movie editedMovie = vm.Movie;

            _context.Update(editedMovie);
            _context.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }

        [HttpPost]
        public IActionResult DeleteMovie(int id)
        {
            Movie movieToDelete = _context.Movies
                .Single(m => m.MovieId == id);

            _context.Movies.Remove(movieToDelete);
            _context.SaveChanges();
            
            return RedirectToAction("ViewMovies");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
