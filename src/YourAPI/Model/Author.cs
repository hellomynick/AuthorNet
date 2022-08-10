using System.Text.Json.Serialization;

namespace YourAPI.Model
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Follower { get; set; }
        [JsonIgnore]
        public List<Book> Books  { get; set; }
    }
}
