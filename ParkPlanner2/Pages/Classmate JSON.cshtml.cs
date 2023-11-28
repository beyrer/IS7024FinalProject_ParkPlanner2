using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClassmateData;
using System.Net.Http;

namespace ParkPlanner2.Pages
{
    public class Classmate_JSONModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        static readonly HttpClient client = new HttpClient();
        public Classmate_JSONModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

            var task = client.GetAsync("https://data.cincinnati-oh.gov/resource/wmj4-ygbf.json\r\n");
            HttpResponseMessage result = task.Result;

            List<Classmate> classmatejson = new List<Classmate>();
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    classmatejson = Classmate.FromJson(jsonString);
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error during API call - Classmate Json", ex);
                }
            }
            ViewData["Classmate"] = classmatejson;

        }
    }
}
