using OnlineBloodManagement.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace OnlineBloodManagement.Models
{
    public class BloodBankInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Blood bank name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only charecter allowed")]
        public string BloodBankName { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "State is required")]
        public string State { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed")]
        [CustomValidationForContact(ErrorMessage = "Invalid Contact number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
