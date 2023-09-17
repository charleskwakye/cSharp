using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MovieContext _context;

        public RatingsController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult List()
        {
            var ratings = _context.Ratings.OrderBy(r => r.Name);
            return View(ratings.ToList());
        }


        //GET: Ratings/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Ratings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        //GET: Ratings/Edit/5
        public IActionResult Edit(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            return View(rating);

        }

        //POST: Ratings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rating);
                    _context.SaveChanges();
                }

                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }

                return RedirectToAction("List");
            }
            return View(rating);
        }

        ////POST: Ratings/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]

        //public IActionResult Edit([Bind("RatingID,Code")] Rating rating)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Ratings.Attach(rating);
        //            //modified rating object gets unchanged state
        //            _context.Entry(rating).Property(r => r.Code).IsModified = true;
        //            //only property code gets changed state
        //            //the whole rating object also get changed state
        //            _context.SaveChanges();
        //        }

        //        catch (DbUpdateConcurrencyException)
        //        {
        //            throw;
        //        }

        //        return RedirectToAction("List");
        //    }
        //    return View(rating);
        //}

        //GET: Ratings/Edit/5
        public IActionResult Delete(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("List");

        }
    }
}
