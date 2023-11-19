using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ParkPlanner2.Pages
{
    public class FeedModel : PageModel
    {
        public JsonResult OnGet()
        {
            return new JsonResult(ReviewList.allReviews);
        }
    }
}
