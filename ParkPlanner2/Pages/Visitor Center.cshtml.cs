using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ParkPlannerVisitor;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

namespace ParkPlanner2.Pages
{
    public class Visitor_CenterModel : PageModel
    {
        public string ParkCode { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public Visitor_CenterModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        static readonly HttpClient client = new HttpClient();
        public void OnGet(string query)
        {
            var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
            string VisitorApiKey = config["PP-API"];


            var task = client.GetAsync("https://developer.nps.gov/api/v1/visitorcenters?api_key=" + VisitorApiKey);
            HttpResponseMessage result = task.Result;
            List<Datum> VC = new List<Datum>();
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    VC = VisitorCenter.FromJson(jsonString).Data;
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var AllVisitorCenter = VC.ToList();
                        var VisitorCenter = AllVisitorCenter.FindAll(x => string.Equals(x.ParkCode, query, StringComparison.OrdinalIgnoreCase)).ToList();

                        if (VisitorCenter != null && VisitorCenter.Count > 0)
                        {

                            ViewData["VisitorCenterList"] = VisitorCenter;
                        }
                        else
                        {
                            ViewData["VisitorCenterList"] = null;
                        }
                    }
                    else
                    {
                        ViewData["VisitorCenterList"] = null;
                    }
                    ParkCode = query;
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error during API call - Visitor Center", ex);
                }
            }
        }
    }
}
