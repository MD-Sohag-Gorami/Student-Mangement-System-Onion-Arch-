using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.ViewModel
{
    public class StudentModel
    {
        public StudentModel()
        {
            EnrolledCourses = new List<Course>();
            TranslateLanguage = new List<SelectListItem>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }

        public int Language { get; set; }
        public IList<SelectListItem> TranslateLanguage { get; set; }

        public string Translation { get; set; }
        public IList<Course>? EnrolledCourses { get; set; }
    }
}
