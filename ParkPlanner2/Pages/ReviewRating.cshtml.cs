using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkPlanner2.Pages
{
    public class ReviewRatingModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public ReviewRatingModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        [BindProperty]
        public Review review { get; set; }

        public void OnGet()
        {
            ViewData["ReviewList"] = ReviewList.allReviews;
        }

        public void OnPost()
        {
            // update the local map. 
            string stuff = review.FirstName + review.LastName + review.ParkName + review.Rating + review.Reviews;
            ReviewList.allReviews.Add(review);

            ViewData["ReviewList"] = ReviewList.allReviews;
        }
    }
}
