using System.Text.Json.Serialization;

namespace MockAPI.Domain;

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public long Followers { get; set; }
    [JsonIgnore]
    public List<Book> Books { get; set; }
}