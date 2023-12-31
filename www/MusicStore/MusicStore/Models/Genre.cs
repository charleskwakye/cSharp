﻿namespace MusicStore.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Album>? Albums { get; set; }
    }
}
