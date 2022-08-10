using Bogus;
using MockAPI.Domain;

namespace MockAPI.Services;

public class DataStore
{
    private readonly List<Author> _authors;
    
    public DataStore()
    {
        Randomizer.Seed = new Random(8675309);
        
        var reviewRule = new Faker<Review>()
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Content, f => f.Lorem.Sentence());
        
        var bookRule = new Faker<Book>()
            .RuleFor(x => x.Id, f => f.Random.Int(0))
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Reviews, f => reviewRule.Generate(f.Random.Int(0, 4)))
            .RuleFor(x => x.Stars, f => f.Random.Double(1, 5));
        
        var authorRule = new Faker<Author>()
            .RuleFor(x => x.Id, f => f.Random.Int(0))
            .RuleFor(x => x.Name, f => f.Name.FullName())
            .RuleFor(x => x.Books, f => bookRule.Generate(f.Random.Int(0, 4)))
            .RuleFor(x => x.Followers, f => f.Random.Int(10, 5000));

        _authors = authorRule.Generate(10);
    }

    public List<Author> GetAuthors()
    {
        return _authors;
    }

    public Author GetAuthor(int id)
    {
        return _authors.FirstOrDefault(x => x.Id == id);
    }
}