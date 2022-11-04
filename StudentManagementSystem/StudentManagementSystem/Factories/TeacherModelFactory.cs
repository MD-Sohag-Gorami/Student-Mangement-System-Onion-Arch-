using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public class TeacherModelFactory : ITeacherModelFactory
    {
        private readonly ICourseService _course;
        private readonly ITeacherService _teacher;
        private readonly ILanguageService _language;
        private readonly ILocalizationService _localization;

        public TeacherModelFactory(ICourseService course, ITeacherService teacher,
                                    ILanguageService language,
                                    ILocalizationService localization)
        {
            _course = course;
            _teacher = teacher;
            _language = language;
            _localization = localization;
        }
        public async Task<TeacherModel> PrepareTeacherModelAsync(TeacherModel viewModel)
        {
            var languages = await _language.GetAllLanguageAsync();

            foreach (var language in languages)
            {
                var item = new SelectListItem()
                {
                    Value = language.Id.ToString(),
                    Text = language.Name,
                };
                viewModel.TranslationLanguage.Add(item);
            }
            return viewModel;
        }
        private async Task<TeacherModel> PrepareTeacherByModelAsync(Teacher model)
        {

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

            var ViewModel = new TeacherModel()
            {
                Id = model.Id,
                Name = model.Name,
                Designation = model.Designation,

                TakenCourses = model.TakenCourses.Select(m => new CourseModel()
                {
                    Id = m.Id,
                    Title = m.Title,
                    Code = m.Code,
                    TeacherId = m.TeacherId,

                }).ToList(),

            };

            var localValue = await _localization.GetLocalizationByIdAsync(defaultLanguageId, "Teacher", model.Id, "Name");
            if (localValue != null) ViewModel.Name = localValue.Value;
            else ViewModel.Name = model.Name ;

            return ViewModel;
        }
        public async Task<List<TeacherModel>> PrepareAllTeacherAsync()
        {
            var model = await _teacher.GetAllTeacherAsync();
           
            List<TeacherModel> teacherList = new List<TeacherModel>();
            foreach (var item in model)
            {
                var createView = await PrepareTeacherByModelAsync(item);
                teacherList.Add(createView);
            }
            return teacherList;
        }
        public async Task<TeacherModel> PrepareTeacherByIdAsync(int id)
        {
            var model = await _teacher.GetTeacherByIdAsync(id);
            model.TakenCourses = await _course.GetAllCourseAsync(teacherId:id);
            var createView = await PrepareTeacherByModelAsync(model);

            return createView;
        }
    }
}
