namespace LaunchCodeCapstone.Models.BlogStyleReview
{
    public class Review
    {
        //guid is unique identifier
        public Guid Id { get; set; }
        public string Heading { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public string FeaturedImageUrl { get; set; }
        public string UrlHandle { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Author { get; set; }
        public bool Visible { get; set; }

        //sets many to many relationship between reviews and tags.
        public ICollection<Tag> Tags { get; set; }

    }
}
