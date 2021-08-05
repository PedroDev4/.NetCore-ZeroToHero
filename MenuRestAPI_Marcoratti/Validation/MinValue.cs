using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRestAPI_Marcoratti.Validation
{
    public class MinValue : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString())) {

                return ValidationResult.Success; // Retorna true or false
            }

            var valueNumber = Convert.ToInt32(value);

            if (valueNumber <= 0) {
                return new ValidationResult("A quantidade minima de estoque é 1");
            }

            return ValidationResult.Success;
        }

    }
}
