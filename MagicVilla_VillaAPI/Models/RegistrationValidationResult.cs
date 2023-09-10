namespace MagicVilla_VillaAPI.Models
{
    public class RegistrationValidationResult
    {
        public bool IsValid { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
