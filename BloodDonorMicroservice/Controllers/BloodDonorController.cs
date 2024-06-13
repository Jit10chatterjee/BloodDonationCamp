using BloodDonorMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BloodDonorMicroservice.Controllers
{
    [Route("BloodDonor")]
    [ApiController]
    public class BloodDonorController : ControllerBase
    {
        BloodDonorDbContext db = null;
        public BloodDonorController(BloodDonorDbContext context)
        {
            db = context;
        }

        [HttpGet]
        //http://localhost:{port}/BloodDonor
        public IActionResult GetAllBloodDonor()
        {
            var donorList = db.BloodDonorInfos.ToList();
            if (donorList.Count() > 0)
            {
                return Ok(donorList);
            }
            return BadRequest("No records found!!");
        }

        [HttpGet]
        [Route("{id}")]
        //http://localhost:{port}/BloodDonor/{id}
        public IActionResult GetBloodDonorById(int id)
        {
            var donor = db.BloodDonorInfos.Find(id);
            if(donor == null)
            {
                return BadRequest($"No donor exists with ID = {id}");
            }
            return Ok(donor);
        }


        [HttpGet]
        [Route("bgroup/{group}")]
        //http://localhost:{port}/BloodDonor/bgroup/{group}
        public IActionResult GetBloodDonorByDonor(string group)
        {
            var donorList = db.BloodDonorInfos.Where(b=>b.BloodGroup == group).ToList();
            if(donorList.Count() > 0)
            {
                return Ok(donorList);
            }
            return BadRequest($"No donor exist with Blood-Group = {group}");
        }
      

        [HttpPost]
        //http://localhost:{port}/BloodDonor
        public IActionResult CreateBloodDonor([FromBody] BloodDonorInfo b)
        {
            if(b == null)
            {
                return BadRequest("Donor object is null");
            }
            db.BloodDonorInfos.Add(b);
            db.SaveChanges();
            return Ok(b.Id);
        }

        [HttpPut]
        [Route("Modified/{id}")]
        //http://localhost:{port}/BloodDonor/Modified/{id}
        public IActionResult EditBloodDonor(int id, [FromBody] BloodDonorInfo bObj)
        {
            if (bObj == null)
            {
                BadRequest("Blood Donor Object is null");
            }
            var donor = db.BloodDonorInfos.Find(id);
            if (donor != null)
            {
                donor.FirstName = bObj.FirstName;
                donor.LastName = bObj.LastName;
                donor.ContactNumber = bObj.ContactNumber;
                donor.BloodGroup = bObj.BloodGroup;
                donor.City = bObj.City;
                donor.Address = bObj.Address;
                donor.DateOfBrith = bObj.DateOfBrith;

                db.BloodDonorInfos.Update(donor);
                db.SaveChanges();
                return Ok(donor);
            }
            return BadRequest($"Id ={id} not exist");
        }


        [HttpDelete]
        [Route("{id}")]
        //http://localhost:{port}/BloodDonor/{id}
        public IActionResult DeleteBloodDonor(int id)
        {
            var donor = db.BloodDonorInfos.Find(id);
            if (donor != null)
            {
                db.BloodDonorInfos.Remove(donor);
                db.SaveChanges();
                return Ok(donor.Id);
            }
            return BadRequest($"Id ={id} not exist");
        }
    }
}
