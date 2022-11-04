using Microsoft.AspNetCore.Mvc.Rendering;

namespace Multi_lingual_student_management_system.ViewModel
{
    public class TeacherModel
    {
        public TeacherModel()
        {
            TranslationLanguage = new List<SelectListItem>();
            TakenCourses = new List<CourseModel>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Language { get; set; }
        public string? Translation { get; set; }
        public string? Designation { get; set; }
        public IList<CourseModel> TakenCourses { get; set; }
        public IList<SelectListItem> TranslationLanguage { get; set; }

    }
}
