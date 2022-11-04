using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.Models
{
    public class Language
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDefault { get; set; }
    }
}
