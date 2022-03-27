using System.ComponentModel.DataAnnotations;

namespace LanguageClassManager.Models
{
    public class AppUser
    {
        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PinCode { get; set; }
    }
}
