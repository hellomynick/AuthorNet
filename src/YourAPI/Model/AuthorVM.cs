namespace YourAPI.Model
{
    public class AuthorVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Follower { get; set; }
        public List<int> BookId { get; set; }
    }
}
