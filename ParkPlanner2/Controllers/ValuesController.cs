using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ParkPlannerPark;

namespace ParkPlanner2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : Controller
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Park> Get()
        //public ActionResult Index()
        //Can't get API to call the below information from the list info nor from Park.cs class tried matching to website table names//
        {
            IList<Park> parks = new List<Park>();
            Park AlagnakWildRiver = new Park();
            AlagnakWildRiver.parkfullname = "Alagnak Wild River";
            AlagnakWildRiver.State = "AK";
            AlagnakWildRiver.TypeofPark = "Wild River";
            parks.Add(AlagnakWildRiver);

            Park AlagnakWildRiver = new Park();
            AlagnakWildRiver.ParkFullName = "Alagnak Wild River";
            AlagnakWildRiver.State = "AK";
            AlagnakWildRiver.TypeofPark = "Wild River";
            parks.Add(AlagnakWildRiver);

            return parks;

            //return View();
        }

        // GET: ValuesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ValuesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValuesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ValuesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ValuesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ValuesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ValuesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
