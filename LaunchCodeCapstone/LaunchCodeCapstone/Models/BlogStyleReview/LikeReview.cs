namespace LaunchCodeCapstone.Models.BlogStyleReview
{
    public class LikeReview
    {
        public Guid Id { get; set; }
        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
    }
}