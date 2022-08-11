using System.Text.Json.Serialization;

namespace YourAPI.Model;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Stars { get; set; }
    public IEnumerable<Review> Reviews { get; set; }
}