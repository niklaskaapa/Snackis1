using Snackis1.Data.Entities;
using Snackis1.Data.Repositories;


namespace Snackis1.Services
{
    public class ForumService
    {

        private readonly IForumRepository _repository;

        public ForumService(IForumRepository repository)
        {
            _repository = repository;
        }





        public async Task<List<Forum>> GetAllForumsAsync()
        {
            return await _repository.GetAllForumsAsync();
        } 

        public async Task AddForumAsync(Forum forum)
        {
            await _repository.AddForumAsync(forum);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _repository.AddCategoryAsync(category);
        }

        public async Task<Category?> GetCategoryByIdAsync(int categoryId)
        {
            return await _repository.GetCategoryByIdAsync(categoryId);
        }

        public async Task AddPostAsync(Post post)
        {
            await _repository.AddPostAsync(post);
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await _repository.GetPostsByCategoryAsync(categoryId);
        }

        public async Task<Post?> GetPostByIdAsync(int postId)
        {
            return await _repository.GetPostByIdAsync(postId);
        }

        public async Task AddCommentAsync(Comment comment)
        {
            await _repository.AddCommentAsync(comment);
        }


        public async Task<List<Comment>> GetCommentsByPostIdAsync(int postId)
        {
            return await _repository.GetCommentsByPostIdAsync(postId);
        }

        public async Task<List<Comment>> GetCommentsByUserAsync(string userId)
        {
            return await _repository.GetCommentsByUserAsync(userId);
        }

        public async Task<List<Post>> GetPostsByUserAsync(string userId)
        {
            return await _repository.GetPostsByUserAsync(userId);
        }


    }
}
