using Microsoft.AspNetCore.Mvc;
using OnlineBloodManagement.Models;
using OnlineBloodManagement.Services;

namespace OnlineBloodManagement.Controllers
{
    public class BloodBankController : Controller
    {
        BloodBankService s = new BloodBankService();
        public IActionResult Index()
        {
            var bloodbankList = s.GetAllBloodBank();
            return View(bloodbankList);
        }

        public IActionResult Details(int id)
        {
            BloodBankInfo b = s.GetBloodBankById(id);
            return View(b);
        }

        [HttpGet]
        public IActionResult GetBloodBankByCity()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetBloodBankByCity(string city)
        {
            var bloodbankList = s.GetBloodBankByCity(city);
            return View(bloodbankList);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BloodBankInfo b)
        {
            if(ModelState.IsValid)
            {
                var bloodbank = s.CreateBloodBank(b);
                return RedirectToAction("Details", new { id = bloodbank});
            }
            return View();
        }

        public IActionResult Edit(int id)
        {
            BloodBankInfo b = s.GetBloodBankById(id);
            return View(b);
        }

        [HttpPost]
        public IActionResult Edit(int id, BloodBankInfo b)
        {
            if (ModelState.IsValid)
            {
                bool r = s.EditBloodBank(id, b);
                if (r == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(b);
        }

        public ActionResult Delete(int id)
        {
            bool r = s.DeleteBloodBank(id);
            if (r == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
