﻿namespace InfinityCinema.Services.Data.MoviesService.Models
{
    using System.Collections.Generic;

    public class MovieListingViewModel
    {
        public MovieListingViewModel()
        {
            Genres = new List<string>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<string> Genres { get; set; }

        public string ImageUrl { get; set; }

        public double StarRating { get; set; }

        public string Duration { get; set; }

        public int YearOfReleassed { get; set; }
    }
}