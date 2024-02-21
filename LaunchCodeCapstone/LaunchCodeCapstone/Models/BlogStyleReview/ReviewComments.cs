namespace LaunchCodeCapstone.Models.BlogStyleReview
{
    public class ReviewComments
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateAdded { get; set; }

    }
}