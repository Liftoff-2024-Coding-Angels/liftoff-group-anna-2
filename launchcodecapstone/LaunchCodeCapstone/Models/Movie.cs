using System.Collections;
using System.Collections.Generic;

namespace LaunchCodeCapstone.Models
{
    public class Movie
    {
        

        public int Id { get; set; }
        public string Title { get; set; }
        public string Overview { get; set; }

        public User? User { get; set; }

        public Rating? Ratings { get; set; }
      
       public Movie(string title, string overview ) 
        {
            Title = title;
            Overview = overview;
        }

        public Movie() 
        {
        }

    }


}

