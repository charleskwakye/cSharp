using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.ViewModels;

namespace MvcMovie.Controllers
{
    public class MoviesController : Controller
    {
        private readonly MovieContext _context;

        public MoviesController(MovieContext context)
        {
            _context = context;
        }

        //public IActionResult List()
        //{
        //    var movies = _context.Movies.OrderBy(m => m.Title);

        //    return View(movies.ToList());
        //}

        public IActionResult List(int ratingID = 0)
        {
            var listMoviesVM = new ListMoviesViewModel();

            if (ratingID != 0)
            {
                listMoviesVM.Movies = _context.Movies.Where(m => m.RatingID == ratingID).OrderBy(m => m.Title).ToList();
            }
            else
            {
                listMoviesVM.Movies = _context.Movies.OrderBy(m => m.Title).ToList();
            }

            listMoviesVM.Ratings = new SelectList(_context.Ratings.OrderBy(r => r.Name), "RatingID", "Name");
            listMoviesVM.ratingID = ratingID;

            return View(listMoviesVM);
        }



        public IActionResult Details(int id)
        {
            Movie movie = _context.Movies
                            .Include(m => m.Rating)
                            .SingleOrDefault(m => m.MovieID == id);

            return View(movie);
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            ViewData["Ratings"] =
                new SelectList(_context.Ratings.OrderBy(r => r.Name),
                               "RatingID",
                               "Name");
            return View();
        }

        //POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("MovieID,Title,RatingID")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(movie);
        }

    }
}
