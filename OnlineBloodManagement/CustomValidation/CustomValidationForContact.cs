using System.ComponentModel.DataAnnotations;

namespace OnlineBloodManagement.CustomValidation
{
    public class CustomValidationForContact:ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value != null)
            {
                string input = value.ToString();
                if (input.Length == 10)
                {
                    string firstDigit = input.Substring(0, 1);
                    if (firstDigit == "9" || firstDigit == "8" || firstDigit == "7" || firstDigit == "6")
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
