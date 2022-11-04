using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public class StudentModelFactory : IStudentModelFactory
    {
        private readonly IStudentService _student;
        private readonly ILanguageService _language;
        private readonly ICourseService _course;
        private readonly ILocalizationService _localization;

        #region Ctor
        public StudentModelFactory(IStudentService student,
                                   ILanguageService language,
                                   ICourseService course,
                                    ILocalizationService localization)
        {


            _student = student;
            _language = language;
            _course = course;
            _localization = localization;
        }
        #endregion
        #region Methods
        public async Task<StudentModel> PrepareStudentModelAsync(StudentModel viewModel)
        {
            var languages = await _language.GetAllLanguageAsync();

            foreach (var language in languages)
            {
                var item = new SelectListItem()
                {
                    Value = language.Id.ToString(),
                    Text = language.Name,
                };
                viewModel.TranslateLanguage.Add(item);
            }
            return viewModel;
        }

        public async Task<List<StudentModel>> PrepareAllStudentAsync()
        {
            var students = await _student.GetAllStudentAsync();
            var languages = await _language.GetAllLanguageAsync();
            int defaultLanguageId = 0;
            for (int i = 0; i < languages.Count; i++)
            {
                if (languages[i].IsDefault == true)
                {
                    defaultLanguageId = languages[i].Id;
                    break;
                }
            }

            List<StudentModel> studentList = new List<StudentModel>();

            foreach (var student in students)
            {

                var ViewModel = new StudentModel()
                {
                    Id = student.Id,
                    Roll = student.Roll,
                };

                var model = await _localization.GetLocalizationByIdAsync(defaultLanguageId, "Student", student.Id, "Name");
                if (model != null) ViewModel.Name = model.Value;
                else ViewModel.Name = student.Name;

                studentList.Add(ViewModel);
            }

            if (studentList == null) return new List<StudentModel>();
            return studentList;


        }
        public async Task<StudentModel> PrepareStudentByIdAsync(int id)
        {
            var student = await _student.GetStudentByIdAsync(id);

            if (student == null) return new StudentModel();

            List<Course> courseList = new List<Course>();

            foreach (var course in student.EnrolledCourses)
            {
                courseList.Add(course);
            }

            var ViewModel = new StudentModel()
            {
                Id = student.Id,
                Name = student.Name,
                Roll = student.Roll,
                EnrolledCourses = student.EnrolledCourses,

            };


            return ViewModel;

        }
        #endregion
    }
}
