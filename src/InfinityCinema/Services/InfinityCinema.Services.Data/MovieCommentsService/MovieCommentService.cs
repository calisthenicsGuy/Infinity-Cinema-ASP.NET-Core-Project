﻿namespace InfinityCinema.Services.Data.MovieCommentsService
{
    using System.Linq;
    using System.Threading.Tasks;

    using InfinityCinema.Data;
    using InfinityCinema.Data.Models;
    using InfinityCinema.Services.Data.ApplicationUsersService;
    using InfinityCinema.Services.Data.ApplicationUsersService.Models;
    using InfinityCinema.Services.Data.MovieCommentsService.Models;

    public class MovieCommentService : IMovieCommentService
    {
        private readonly InfinityCinemaDbContext dbContext;
        private readonly IApplicationUserService userService;

        public MovieCommentService(InfinityCinemaDbContext dbContext, IApplicationUserService userService)
        {
            this.dbContext = dbContext;
            this.userService = userService;
        }

        // Create
        public async Task<MovieCommentViewModel> CreateAsync(MovieCommentFormModel comment)
        {
            MovieComment movieComment = new MovieComment()
            {
                Content = comment.Content,
                UserId = comment.UserId,
                Likes = 0,
                Dislikes = 0,
            };

            await this.dbContext.MovieComments.AddAsync(movieComment);
            await this.dbContext.SaveChangesAsync();

            return new MovieCommentViewModel()
            {
                Id = movieComment.Id,
                Content = movieComment.Content,
                User = this.userService.GetViewModelById<ApplicationUserViewModel>(movieComment.UserId),
            };
        }

        // Read

        // Update
        public async Task<int> IncreaseCommentLikesAsync(int commentId)
        {
            MovieComment movieComment = this.dbContext
                .MovieComments
                .FirstOrDefault(m => m.Id == commentId);

            movieComment.Likes++;

            await this.dbContext.SaveChangesAsync();

            return movieComment.Likes;
        }

        public async Task<int> IncreaseCommentDislikesAsync(int commentId)
        {
            MovieComment movieComment = this.dbContext
                .MovieComments
                .FirstOrDefault(m => m.Id == commentId);

            movieComment.Dislikes++;

            await this.dbContext.SaveChangesAsync();

            return movieComment.Dislikes;
        }
    }
}
