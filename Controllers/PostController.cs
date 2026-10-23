using Microsoft.AspNetCore.Mvc;
using Snackis1.API.DTO;
using Snackis1.Services;

namespace Snackis1.Controllers
{

    [ApiController]
    [Route("api/post")]
    public class PostController : ControllerBase
    {
        private readonly ForumService _forumService;

        public PostController(ForumService forumService) 
        {
            _forumService = forumService;
        }



        [HttpGet("{id:int}")]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var post = await _forumService.GetPostByIdAsync(id);

            if (post == null)
            {
                return NotFound();
            }

            var comments = await _forumService.GetCommentsByPostIdAsync(id);

            var result = new PostDto
            {
                Title = post.Title,
                Content = post.Content,
                Author = post.User?.UserName ?? "Okänd användare",
                UserId = post.UserId,
                ProfileImageUrl = post.User?.ProfileImageUrl,
                CreatedAt = post.CreatedAt,
                CategoryId = post.CategoryId,
                CategoryName = post.Category?.Name ?? "",
                ForumTitle = post.Category?.Forum?.Title ?? "",
                Comments = comments.Select(c => new CommentDto
                {
                    Content = c.Content,
                    Author = c.User?.UserName ?? "Okänd användare",
                    UserId =c.UserId,
                    ProfileImageUrl = c.User?.ProfileImageUrl,
                    CreatedAt = c.CreatedAt
                }).ToList()
            };

            return Ok(result);
        }





    }
}
