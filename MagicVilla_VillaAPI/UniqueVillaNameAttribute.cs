using MagicVilla_VillaAPI.Models.Dto;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MagicVilla_VillaAPI
{
   
    public class UniqueVillaNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string villaName = value.ToString();
                //var villaList = (VillaDTO[])validationContext.ObjectInstance;
                var villaList = validationContext.ObjectInstance as IEnumerable<VillaDTO>;

                    if (villaList != null && villaList.Any(villa => villa.Name.ToLower() == villaName.ToLower()))
                    {
                    return new ValidationResult("Villa Name Already Exists");
                }
            }

            return ValidationResult.Success;
        }
    }

}
