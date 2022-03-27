using LanguageClassManager.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanguageClassManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [Required]
        [Range(18, 27, ErrorMessage = "Currently we don't have vacant courses for you")]
        public int Age { get; set; }
        //Language
        public int LanguageClassId { get; set; }
        public LanguageClass? LanguageClass { get; set; }
        // StudyType Maybe online offline or mixed
        public StudyType StudyType { get; set; }

    }
}
