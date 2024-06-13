using BloodBankMicroservice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodBankMicroservice.Controllers
{
    [Route("BloodBank")]
    [ApiController]
    public class BloodBankController : ControllerBase
    {
        BloodBankdbContext db = null;
        public BloodBankController(BloodBankdbContext context)
        {
            db = context;
        }

        [HttpGet]
        //https://localhost:{port}/BloodBank
        public IActionResult GetAllBloodBanks()
        {
            var bloodbankList = db.BloodBankInfos.ToList();
            if (bloodbankList.Count() > 0)
            {
                return Ok(bloodbankList);
            }
            return BadRequest("No record found");
        }


        [HttpGet]
        [Route("{id}")]
        //https://localhost:{port}/BloodBank/id
        public IActionResult GetBloodBankById(int id)
        {
            var bloodbank = db.BloodBankInfos.SingleOrDefault(b => b.Id == id);
            if (bloodbank == null)
            {
                return BadRequest($"No records found by id = {id}");
            }
            return Ok(bloodbank);
        }

        [HttpGet]
        [Route("find/{city}")]
        //https://localhost:{port}/BloodBank/find/city
        public IActionResult GetBloodBankByCity(string city)
        {
            var bloodbankList = db.BloodBankInfos.Where(b=>b.City == city).ToList();
            if(bloodbankList.Count() > 0)
            {
                return Ok(bloodbankList);
            }
            return BadRequest($"No records found by city = {city}");
        }


        [HttpPost]
        //https://localhost:{port}/BloodBank
        public IActionResult CreateBloodBank([FromBody] BloodBankInfo b)
        {
            if(b != null)
            {
                db.BloodBankInfos.Add(b);
                db.SaveChanges();
                return Ok(b.Id);
            }
            return BadRequest("No inserted");
        }


        [HttpPut]
        [Route("Modified/{id}")]
        //https://localhost:{port}/BloodBank/Modified/id
        public IActionResult EditBloodBank(int id, [FromBody] BloodBankInfo bObj)
        {
            if(bObj == null)
            {
                BadRequest("BloodBank Object is null");
            }
            var bloodbank = db.BloodBankInfos.Find(id);
            if (bloodbank != null)
            {
                bloodbank.BloodBankName = bObj.BloodBankName;
                bloodbank.City = bObj.City;
                bloodbank.State = bObj.State;
                bloodbank.ContactNumber = bObj.ContactNumber;
                bloodbank.Address = bObj.Address;

                db.BloodBankInfos.Update(bloodbank);
                db.SaveChanges();
                return Ok(bloodbank);
            }
            return BadRequest($"Id ={id} not exist");
        }


        [HttpDelete]
        [Route("{id}")]
        //https://localhost:{port}/BloodBank/id
        public IActionResult DeleteBloodBank(int id)
        {
            var bloodbank = db.BloodBankInfos.Find(id);
            if (bloodbank != null)
            {
                db.BloodBankInfos.Remove(bloodbank);
                db.SaveChanges();
                return Ok($"Id={id} is deleted");
            }
            return BadRequest($"Id ={id} not exist");
        }
    }
}
