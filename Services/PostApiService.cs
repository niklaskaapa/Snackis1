using Snackis1.Services.ApiModels;


namespace Snackis1.Services
{
    public class PostApiService
    {
        private readonly HttpClient _httpClient;

        public PostApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<PostApiDto?> GetPostByIdAsync(int postId)
        {
            return await _httpClient.GetFromJsonAsync<PostApiDto>(
                $"api/post/{postId}");
        }
        
    }
}
