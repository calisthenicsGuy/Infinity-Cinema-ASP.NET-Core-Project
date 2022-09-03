﻿namespace InfinityCinema.Services.Data.MoviesService
{
    using System.Collections.Generic;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using InfinityCinema.Data.Models;
    using InfinityCinema.Services.Data.MoviesService.Enums;
    using InfinityCinema.Services.Data.MoviesService.Models;

    public interface IMovieService
    {
        // Create
        Task<Movie> CreateAsync(MovieFormModel movieFormModel, int dealerId, int countryId, string userId);

        Task<string> CreateMovieAsync(CreateMovieServiceModel movieModel, ClaimsPrincipal user);

        // Read
        MovieDetailsViewModel Details(int id);

        Task<MovieFormModel> GetMovieById(int id);

        AllMoviesQueryModel All(string searchName, MovieSorting sorting, int currentPage, int moviesPerPage, string searchGenre);

        IEnumerable<MovieHomeViewModel> GetTopThreeRatedMovies();

        MovieStatisticsViewModel MovieStatistics();

        IEnumerable<UserSavedMovieViewModel> GetUserSavedMovies(string userId);

        // Update
        Task<bool> EditAsync(EditMovieServiceModel movieModel);

        // Delete
        Task<bool> DeleteAsync(DeleteMovieServiceModel deleteMovieServiceModel);

        bool CheckIfMovieWithGivenIdExist(int id);
    }
}
