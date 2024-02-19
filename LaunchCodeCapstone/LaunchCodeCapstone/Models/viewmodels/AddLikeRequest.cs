namespace LaunchCodeCapstone.Models.ViewModels
{
    public class AddLikeRequest
    {

        public Guid ReviewId { get; set; }
        public Guid UserId { get; set; }
    }
}