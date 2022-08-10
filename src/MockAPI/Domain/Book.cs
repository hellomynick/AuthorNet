using System.Text.Json.Serialization;

namespace MockAPI.Domain;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Stars { get; set; }
    [JsonIgnore]
    public List<Review> Reviews { get; set; }
}