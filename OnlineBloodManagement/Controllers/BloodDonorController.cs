using Microsoft.AspNetCore.Mvc;
using OnlineBloodManagement.Models;
using OnlineBloodManagement.Services;

namespace OnlineBloodManagement.Controllers
{
    public class BloodDonorController : Controller
    {
        BloodDonorService s = new BloodDonorService();
        public IActionResult Index()
        {
            var donorList = s.GetAllDonor();
            return View(donorList);
        }

        public IActionResult Details(int id)
        {
            var b = s.GetDoonorById(id);
            return View(b);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BloodDonorInfo b)
        {
            if (ModelState.IsValid)
            {            
                var donorId = s.CreateBloodDonor(b);
                return RedirectToAction("Details", new { id = donorId });
            }
            return View();           
        }

        public IActionResult Edit(int id)
        {
            var b = s.GetDoonorById(id);
            return View(b);
        }

        [HttpPost]
        public IActionResult Edit(int id, BloodDonorInfo b)
        {
            if (ModelState.IsValid)
            {
                bool r = s.EditBloodDonor(id, b);
                if (r == true)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(b);
        }

        public ActionResult Delete(int id)
        {
            bool r = s.DeleteBloodDonor(id);
            if (r == true)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult GetDonorByGroup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetDonorByGroup(string group)
        {
            var b = s.GetDonorByGroup(group);
            return View(b);
        }

    }
}
