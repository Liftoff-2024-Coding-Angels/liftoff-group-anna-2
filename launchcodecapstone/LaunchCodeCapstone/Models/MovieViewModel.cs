using Microsoft.AspNetCore.Mvc.Rendering;

namespace LaunchCodeCapstone.Models
{
    public class MovieViewModel
    {
        public int Title { get; set; }
        public string Overview { get; set; }

        public List<SelectListItem> Movies { get; set; } = new List<SelectListItem>();

    }
}