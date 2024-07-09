using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using restate.db;

namespace restate.RealEstateManagement.Validators;

public class UniqueValidatorAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
    {
        var context = (AppDbContext)validationContext.GetService(typeof(AppDbContext));
        if(!context.RealEstates.Any(re => re.Name == value.ToString()))
        {
            return ValidationResult.Success;
        }
        return new ValidationResult("Real Estate with provided name already exists");
    }
}