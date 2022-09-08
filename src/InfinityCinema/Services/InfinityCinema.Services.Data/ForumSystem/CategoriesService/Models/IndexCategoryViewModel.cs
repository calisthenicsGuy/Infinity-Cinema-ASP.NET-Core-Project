﻿namespace InfinityCinema.Services.Data.ForumSystem.CategoriesService.Models
{
    using InfinityCinema.Data.Models.ForumSystem;
    using InfinityCinema.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }
    }
}
