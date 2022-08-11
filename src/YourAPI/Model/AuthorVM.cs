namespace YourAPI.Model
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Followers { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public double Stars { get; set; }
        public List<Book> ListBook()
        {
            Book book = new Book();
            book.Id = BookId;
            book.Name = BookName;
            return new List<Book>();
        }
    }
}
