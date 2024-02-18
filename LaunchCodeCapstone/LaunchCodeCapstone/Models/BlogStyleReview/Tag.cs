namespace LaunchCodeCapstone.Models.BlogStyleReview
{
    public class Tag
    {
        public Guid Id { get; set; }
        public string Name { get; set; }    
        public string DisplayName { get; set; }

        //sets many to many relationship between reviews and tags.
        public ICollection<Review> Reviews { get; set; }
    }
}
