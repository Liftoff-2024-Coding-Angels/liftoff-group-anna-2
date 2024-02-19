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

        //nav property sets one to many relationship between reviews and the likes and comments 
        public ICollection<LikeReview> Likes { get; set; }
        public ICollection<ReviewComments> Comments { get; set; }

    }
}