using System.ComponentModel.DataAnnotations;

namespace BloodDonorMicroservice.Models
{
    public class BloodDonorInfo
    {
        [Key]
        public int Id { get; set; }       
        public string FirstName { get; set; }      
        public string LastName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string BloodGroup {  get; set; }
        public string City { get; set; }
        public string Address { get; set; }
    }
}
