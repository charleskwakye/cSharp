using Microsoft.AspNetCore.Mvc.Rendering;
namespace MusicStore.Models.ViewModels
{
    public class AlbumsViewModel
    {
        public List<Album> Albums { get; set; }
        public SelectList Genres { get; set; }
        public int genreID { get; set; }

        public SelectList Artists { get; set; }
        public int artistID { get; set; }

        public String Title { get; set; }
    }
}
