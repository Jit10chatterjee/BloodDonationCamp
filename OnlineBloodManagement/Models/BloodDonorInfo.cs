using System.ComponentModel.DataAnnotations;
using OnlineBloodManagement.CustomValidation;

namespace OnlineBloodManagement.Models
{
    public class BloodDonorInfo
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only charecter allowed")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Only charecter allowed")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Contact is required")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers allowed")]
        [CustomValidationForContact(ErrorMessage = "Invalid Contact number")]
        public string ContactNumber { get; set; }

        [Required(ErrorMessage ="Please provide the date")]
        public DateTime DateOfBrith { get; set; }

        [RegularExpression("^(A|B|AB|O)[+-]$", ErrorMessage = "Invalid blood group")]
        [Required(ErrorMessage ="Blood group is required")]
        public string BloodGroup { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }
    }
}
