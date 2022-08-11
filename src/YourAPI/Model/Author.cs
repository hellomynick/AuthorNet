using System.Text.Json.Serialization;

namespace YourAPI.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Followers { get; set; }
        public IEnumerable<Book> Books  { get; set; } = new List<Book>();
    }
}
