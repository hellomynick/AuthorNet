using YourAPI.Model;

namespace YourAPI.ApiIntergration
{
    public interface IAuthorApiClient
    {
        Task<Author> GetAuthorById(int id);
        Task<Author> GetBookByAuthorId(int id);
    }
}
