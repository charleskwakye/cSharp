﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;
using MusicStore.Models.ViewModels;

namespace MusicStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Administrator")]
    public class AlbumsController : Controller
    {
        private readonly StoreContext _context;

        public AlbumsController(StoreContext context)
        {
            _context = context;
        }

        // GET: Admin/Albums
        public async Task<IActionResult> Index(int genreID = 0, int artistID = 0, string Title = null)
        {
            var AlbumsVM = new AlbumsViewModel();

            AlbumsVM.Genres = new SelectList(_context.Genres.OrderBy(g => g.Name), "GenreID", "Name");

            AlbumsVM.Artists = new SelectList(_context.Artists.OrderBy(a => a.Name), "ArtistID", "Name");

            var query = _context.Albums.Include(a => a.Artist).Include(a => a.Genre).AsQueryable();

            if (genreID != 0)
            {
                query = query.Where(a => a.GenreID == genreID);
            }

            if (artistID != 0)
            {
                query = query.Where(a => a.ArtistID == artistID);
            }

            if (!String.IsNullOrEmpty(Title))
            {
                query = query.Where(a => a.Title.Contains(Title));
            }
            AlbumsVM.Albums = await query.ToListAsync();



            return View(AlbumsVM);
        }

        // GET: Admin/Albums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // GET: Admin/Albums/Create
        public IActionResult Create()
        {
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID");
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID");
            return View();
        }

        // POST: Admin/Albums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AlbumID,GenreID,ArtistID,Title,Price,AlbumArtUrl")] Album album)
        {
            if (ModelState.IsValid)
            {
                _context.Add(album);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", album.GenreID);
            return View(album);
        }

        // GET: Admin/Albums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", album.GenreID);
            return View(album);
        }

        // POST: Admin/Albums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AlbumID,GenreID,ArtistID,Title,Price,AlbumArtUrl")] Album album)
        {
            if (id != album.AlbumID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(album);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AlbumExists(album.AlbumID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArtistID"] = new SelectList(_context.Artists, "ArtistID", "ArtistID", album.ArtistID);
            ViewData["GenreID"] = new SelectList(_context.Genres, "GenreID", "GenreID", album.GenreID);
            return View(album);
        }

        // GET: Admin/Albums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var album = await _context.Albums
                .Include(a => a.Artist)
                .Include(a => a.Genre)
                .FirstOrDefaultAsync(m => m.AlbumID == id);
            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }

        // POST: Admin/Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Albums == null)
            {
                return Problem("Entity set 'StoreContext.Albums'  is null.");
            }
            var album = await _context.Albums.FindAsync(id);
            if (album != null)
            {
                _context.Albums.Remove(album);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AlbumExists(int id)
        {
            return _context.Albums.Any(e => e.AlbumID == id);
        }
    }
}
