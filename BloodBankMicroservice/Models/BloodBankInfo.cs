using System.ComponentModel.DataAnnotations;

namespace BloodBankMicroservice.Models
{
    public class BloodBankInfo
    {      
        public int Id { get; set; }
        public string BloodBankName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactNumber { get; set; }
        public string Address { get; set; }
    }
}
