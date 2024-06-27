using Blogging.Commands;
using Blogging.Models;
using Blogging.Queries;
using Blogging.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Blogging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BloggingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BloggingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("AddBlog")]
        public async Task<IActionResult> AddBlog([FromBody] CreateBlogCommand command)
        {
            var blogId = await _mediator.Send(command);
            return Ok($"Blog added successfully with ID: {blogId}");
        }

        [HttpPost("AddPost")]
        public async Task<IActionResult> AddPost([FromBody] CreatePostCommand command)
        {
            var postId = await _mediator.Send(command);
            return Ok($"Post added successfully with ID: {postId}");
        }

        [HttpPost("RegisterAuthor")]
        public async Task<IActionResult> RegisterAuthor([FromBody] RegisterAuthorCommand command)
        {
            var authorId = await _mediator.Send(command);
            return Ok($"Author registered successfully with ID: {authorId}");
        }

        [HttpGet("GetPostsByBlog/{blogId}")]
        public async Task<IActionResult> GetPostsByBlog(int blogId)
        {
            var query = new GetBlogPostsQuery { BlogId = blogId };
            var posts = await _mediator.Send(query);
            if (posts == null || !posts.Any())
            {
                return NotFound("Blog not found or no posts available.");
            }
            return Ok(posts);
        }

        [HttpGet("GetBlogsByAuthor/{authorId}")]
        public async Task<IActionResult> GetBlogsByAuthor(int authorId)
        {
            var query = new GetBlogsByAuthorQuery { AuthorId = authorId };
            var blogs = await _mediator.Send(query);
            if (blogs == null || !blogs.Any())
            {
                return NotFound("Author not found or no blogs available.");
            }
            return Ok(blogs);
        }
    }


}
