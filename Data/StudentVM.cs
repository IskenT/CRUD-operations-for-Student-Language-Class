using LanguageClassManager.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LanguageClassManager.Data
{
    public class StudentVM
    {
        public Student Student { get; set; } 
        public IEnumerable<SelectListItem> LanguageClasses { get; set; }
    }
}
