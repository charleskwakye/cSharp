using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;

namespace MusicStore.Components
{
    [ViewComponent(Name = "GenreMenu")]
    public class GenreMenuComponent : ViewComponent
    {
        private readonly StoreContext _context;

        public GenreMenuComponent(StoreContext context)
        {
            _context = context;
        }

        //get first 8 genres
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres = await _context.Genres.OrderBy(g => g.Name).Take(8).ToListAsync();
            return View(genres);
        }
    }
}
