using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkPlanner2
{
    public class ReviewList
    {
        static ReviewList()
        {
            allReviews = new List<Review>();
        }

        public static IList<Review> allReviews { get; set; }
    }
}
