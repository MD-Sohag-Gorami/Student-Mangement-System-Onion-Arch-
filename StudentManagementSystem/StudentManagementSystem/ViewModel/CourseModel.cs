using Microsoft.AspNetCore.Mvc.Rendering;

namespace Multi_lingual_student_management_system.ViewModel
{
    public class CourseModel
    {
        public CourseModel()
        {
            AvailableLanguage = new List<SelectListItem>();
            TakenCourse = new List<SelectListItem>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int TeacherId { get; set; }
        public string? CourseTeacher { get; set; }
        public IList<SelectListItem>? TakenCourse { get; set; }
       
        public IList<SelectListItem>? AvailableLanguage { get; set; }


    }
}
