namespace LaunchCodeCapstone.Models.ViewModels
{
    public class ReviewComments
    {
        //when a usr makes comment it creates this object, which is called in the viewmodel
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }
        public string Username { get; set; }
    }
}