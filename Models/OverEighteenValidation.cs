using System.ComponentModel.DataAnnotations;

public class OverEighteenValidation : ValidationAttribute
{
  protected override ValidationResult IsValid(object value, ValidationContext context)
  {
    DateTime _dateJoin = Convert.ToDateTime(value);
    if (_dateJoin < DateTime.Now)
    {
      return ValidationResult.Success;
    }
    else
    {
      return new ValidationResult("Must be 18 years or older to register!");
    }
  }

}