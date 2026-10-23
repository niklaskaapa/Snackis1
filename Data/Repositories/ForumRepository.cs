using Microsoft.EntityFrameworkCore;
using Snackis1.Data.Entities;

namespace Snackis1.Data.Repositories
{
    public class ForumRepository : IForumRepository
    {

        private readonly ApplicationDbContext _context;

        public ForumRepository(ApplicationDbContext context)
        {
            _context = context;
        }




        public async Task<List<Forum>> GetAllForumsAsync()
        {
            return await _context.Forums
                .Include(f => f.Categories)
                    .ThenInclude(c => c.Posts)
                .ToListAsync();
        }

        public async Task AddForumAsync(Forum forum)
        {
            _context.Forums.Add(forum);
            await _context.SaveChangesAsync();
        }


        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c =>c.Forum)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }

        public async Task AddPostAsync(Post post)
        {
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await _context.Posts
                .Where(p => p.CategoryId == categoryId)
                .Include(p => p.User)
                .Include(p => p.Comments)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _context.Posts
                .Include(p => p.User)
                .Include(p => p.Category)
                    .ThenInclude(c => c!.Forum)
                .FirstOrDefaultAsync(p => p.Id == postId);
        }


        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _context.Comments
                .Where(c => c.PostId == postId)
                .Include(c => c.User)
                .OrderBy(c => c.CreatedAt)
                .ToListAsync();

        }

        public async Task<List<Comment>> GetCommentsByUserAsync(string userId)
        {
            return await _context.Comments
                .Where(c => c.UserId == userId)
                .Include(c => c.Post)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();
        }

        public async Task<List<Post>> GetPostsByUserAsync(string userId)
        {
            return await _context.Posts
                .Where(p => p.UserId == userId)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();
        }


    }
}
