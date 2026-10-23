using Snackis1.Data.Entities;

namespace Snackis1.Data.Repositories
{
    public interface IForumRepository
    {
        Task AddCategoryAsync(Category category);
        Task AddForumAsync(Forum forum);
        Task<List<Forum>> GetAllForumsAsync();

        Task<Category?> GetCategoryByIdAsync(int categoryId);

        Task AddPostAsync(Post post);

        Task<List<Post>> GetPostsByCategoryAsync(int categoryId);

        Task<Post?> GetPostByIdAsync(int postId);

        Task AddCommentAsync(Comment comment);

        Task<List<Comment>> GetCommentsByPostIdAsync(int postId);
        Task<List<Comment>> GetCommentsByUserAsync(string userId);

        Task<List<Post>> GetPostsByUserAsync(string userId);

    }
}