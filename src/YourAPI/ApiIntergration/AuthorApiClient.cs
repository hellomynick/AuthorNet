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
            var data = await GetAsync<Author>($"/authors/{id}");
            return data;
        }

        public async Task<Author> GetBookByAuthorId(int id)
        {
            var data = await GetAsync<Author>($"/authors/{id}/books");
            return data;
        }
    }
}