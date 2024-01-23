using System;
using System.Diagnostics.Eventing.Reader;

namespace LaunchCodeCapstone.Models
{
	public class HasWatched
	{
        public int HaveWatchedId { get; set; }	]
		public bool HaveOrHaveNotWatched { get; set; }

		public HasWatched(bool haveOrHaveNotWatched)
		{
			HaveOrHaveNotWatched = haveOrHaveNotWatched;
		}

        public HasWatched()
        {
        }
    }
}

