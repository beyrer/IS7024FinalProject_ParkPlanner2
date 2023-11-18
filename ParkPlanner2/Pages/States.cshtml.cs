using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkPlannerPark;
using System.Net.Http;

namespace ParkPlanner2.Pages
{
    public class StatesModel : PageModel
    {
        public List<string> AllStates { get; set; }
        public string Search { get; set; }
        public SelectList States { get; set; }
        private readonly ILogger<IndexModel> _logger;
        public StatesModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        static readonly HttpClient client = new HttpClient();

        public void OnGet(string query)
        {
            var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();
            string ParksApiKey = config["PP-API"];

            InitAreaDropDown();
            var task = client.GetAsync("https://developer.nps.gov/api/v1/parks?api_key=" + ParksApiKey);
            HttpResponseMessage result = task.Result;
            List<Datum> states = new List<Datum>();
            if (result.IsSuccessStatusCode)
            {
                try
                {
                    Task<string> readString = result.Content.ReadAsStringAsync();
                    string jsonString = readString.Result;
                    states = Park.FromJson(jsonString).Data;
                    if (!string.IsNullOrWhiteSpace(query))
                    {
                        var Allstates = states.ToList();
                        var StateParks = Allstates.FindAll(x => string.Equals(x.States, query, StringComparison.OrdinalIgnoreCase)).ToList();

                        if (StateParks != null && StateParks.Count > 0)
                        {

                            ViewData["StateList"] = StateParks;
                        }
                        else
                        {
                            ViewData["StateList"] = null;
                        }
                    }
                    else
                    {
                        ViewData["StateList"] = null;
                    }
                    Search = query;
                }
                catch (Exception ex) 
                {
                    _logger.LogError("Error during API call - States", ex);
                }
            }
        }
        private void InitAreaDropDown()
        {
            AllStates = new List<string>
            {
                {"AL" },
                {"AK"} ,
                {"AZ"} ,
                {"AR"} ,
                {"CA"} ,
                {"CO"} ,
                {"CT"} ,
                {"DE"} ,
                {"FL"} ,
                {"GA"} ,
                {"HI"} ,
                {"ID"} ,
                {"IL"} ,
                {"IN"} ,
                {"IA"} ,
                {"KS"} ,
                {"KY"} ,
                {"LA"} ,
                {"ME"} ,
                {"MD"} ,
                {"MA"} ,
                {"MI"} ,
                {"MN"} ,
                {"MS"} ,
                {"MO"} ,
                {"MT"} ,
                {"NE"} ,
                {"NV"} ,
                {"NH"} ,
                {"NJ"} ,
                {"NM"} ,
                {"NY"} ,
                {"NC"} ,
                {"ND"} ,
                {"OH"} ,
                {"OK"} ,
                {"OR"} ,
                {"PA"} ,
                {"RI"} ,
                {"SC"} ,
                {"SD"} ,
                {"TN"} ,
                {"TX"} ,
                {"UT"} ,
                {"VT"} ,
                {"VA"} ,
                {"WA"} ,
                {"WV"} ,
                {"WI"} ,
                {"WY"} ,
            };

            ViewData["Search"] = new SelectList(AllStates);
        }
    }
}
