using LaunchCodeCapstone.Models.BlogStyleReview;

namespace LaunchCodeCapstone.Models.ViewModels
{
    public class ReviewDetailsViewModel
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
        public int TotalLikes { get; set; }
        public bool Liked { get; set; }
        public string CommentDescription { get; set; }
        public IEnumerable<ReviewComments> Comments { get; set; }


    }
}