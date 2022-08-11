﻿using YourAPI.Model;

namespace YourAPI.ApiIntergration
{
    public interface IAuthorApiClient
    {
        Task<Author> GetAuthorById(int id);
        Task<List<Book>> GetBookByAuthorId(int id);
        Task<List<Review>> GetReview(int authorId,int bookId);
    }
}
