using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RealEstate.Attributes
{
    public class DOB18Over: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            DateTime dob;
            try { dob = Convert.ToDateTime(value); }
            catch (InvalidCastException exc) { return new ValidationResult(ErrorMessage); }
            if (DateTime.Today.AddYears(-18) >= dob)
                return ValidationResult.Success;
            else
                return new ValidationResult("You must be 18 years or old");
        }
    }
}