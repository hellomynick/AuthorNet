using YourAPI.Model;

namespace YourAPI.ApiIntergration
{
    public class AuthorApiClient : BaseApiClient, IAuthorApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AuthorApiClient(IHttpClientFactory httpClientFactory)
             : base(httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<Author> GetAuthorById(int id)
        {
            var data = await GetAsync<Author>($"/authors/{id}/");
            return data;
        }

        public async Task<List<Book>> GetBookByAuthorId(int id)
        {
            var data = await GetListAsync<Book>($"/authors/{id}/books/");
            return data;
        }

        public async Task<List<Review>> GetReview(int authorId,int bookId)
        {
            var data = await GetListAsync<Review>($"/authors/{authorId}/books/{bookId}/reviews");
            return data;
        }
    }
}