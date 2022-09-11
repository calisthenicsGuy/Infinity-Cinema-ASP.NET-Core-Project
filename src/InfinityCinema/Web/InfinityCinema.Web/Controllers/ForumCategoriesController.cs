﻿namespace InfinityCinema.Web.Controllers
{
    using System.Threading.Tasks;

    using InfinityCinema.Services.Data.ForumSystem.CategoriesService;
    using InfinityCinema.Services.Data.ForumSystem.CategoriesService.Models;
    using InfinityCinema.Services.Data.ForumSystem.CategoriesService.Models.Enums;
    using InfinityCinema.Services.Data.ForumSystem.CommentsService;
    using InfinityCinema.Services.Data.ForumSystem.CommentsService.Models;
    using InfinityCinema.Services.Data.ForumSystem.PostsService;
    using InfinityCinema.Services.Data.ForumSystem.PostsService.Models;
    using InfinityCinema.Web.Infrastructure;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ForumCategoriesController : BaseController
    {
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        private readonly IPostService postService;

        public ForumCategoriesController(ICategoryService categoryService, IPostService postService, ICommentService commentService)
        {
            this.categoryService = categoryService;
            this.postService = postService;
            this.commentService = commentService;
        }

        [HttpGet]
        public IActionResult GetCategory([FromQuery] CategoryServiceModel categoryService)
        {
            CategoryServiceModel categoryServiceResult = this.categoryService.ViewCategory(categoryService.CategoryId, categoryService.CurrentPage, categoryService.PostsSorting);

            return this.View(categoryServiceResult);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetCategoryAsync(CommentFormModel comment, int categoryId)
        {
            comment.UserId = ClaimsPrincipalExtensions.GetId(this.User);

            // !!!
            //if (!this.ModelState.IsValid)
            //{
            //    return this.View(categoryServiceModel);
            //}

            await this.commentService.CreateAsync<CommentViewModel>(comment);

            return this.RedirectToAction(nameof(this.GetCategory), "ForumCategories", new { categoryId = categoryId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult CreatePostForCategory(int categoryId)
        {
            this.ViewData["CategoryTitle"] = this.categoryService.GetViewModelById<CategoryViewModel>(categoryId).Title;

            return this.View(new PostFormModel());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePostForCategoryAsync(PostFormModel postFormModel, int categoryId)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(postFormModel);
            }

            postFormModel.UserId = ClaimsPrincipalExtensions.GetId(this.User);
            postFormModel.CategoryId = categoryId;

            await this.postService.CreateAsync<PostViewModel>(postFormModel);

            return this.RedirectToAction(nameof(this.GetCategory), "ForumCategories", new { categoryId = categoryId });
        }
    }
}
