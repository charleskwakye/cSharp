using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> ListGenres()
        {
            var genres = await _context.Genres.OrderBy(g => g.Name).ToListAsync();
            return View(genres);
        }

        public async Task<IActionResult> ListAlbums(int? id)
        {
            //
            ViewData["GenreNameOfAlbums"] = _context.Genres.Where(g => g.GenreID == id).Select(g => g.Name).FirstOrDefault().ToString();
            //get albums of the selected genre using id
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            var albums = await _context.Albums
                .Where(a => a.GenreID == id)
                .OrderBy(a => a.Title)
                .ToListAsync();
            return View(albums);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Albums == null)
            {
                return NotFound();
            }

            //get album using album id
            var album = await _context.Albums.Include(a => a.Genre).Include(a => a.Artist).FirstOrDefaultAsync(a => a.AlbumID == id);

            if (album == null)
            {
                return NotFound();
            }

            return View(album);
        }
    }
}
