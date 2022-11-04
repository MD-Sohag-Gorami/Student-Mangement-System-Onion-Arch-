using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.ViewModel
{
    public class LanguageModel
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Name : ")]
        [Required]
        public string Name { get; set; }

        public bool IsDefault { get; set; }
    }
}
