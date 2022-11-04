using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public class CourseModelFactory : ICourseModelFactory
    {
        private readonly ITeacherService _teacher;
        private readonly ICourseService _course;

        #region Ctor
        public CourseModelFactory(ITeacherService teacher,
                                   ICourseService course)
        {
            _teacher = teacher;
            _course = course;
        }
        #endregion
        #region Methods
        public async Task<CourseModel> PrepareCourseModelAsync(CourseModel viewModel)
        {
            var teachers = await _teacher.GetAllTeacherAsync();
            //viewModel.AvaiableWarehouse = warehouses.Select(x => new SelectListItem()
            //{
            //    Text = x.Name,
            //    Value = x.Id.ToString()
            //}).ToList() ;

            foreach (var teacher in teachers)
            {
                var item = new SelectListItem()
                {
                    Value = teacher.Id.ToString(),
                    Text = teacher.Name,
                };
                viewModel.TakenCourse.Add(item);
            }
            return viewModel;
        }

        public async Task<List<CourseModel>> PrepareAllCourseAsync()
        {
            var courses = await _course.GetAllCourseAsync();
            List<CourseModel> courseList = new List<CourseModel>();

            foreach (var course in courses)
            {

                CourseModel ViewModel = new CourseModel()
                {
                    Id = course.Id,
                    Title = course.Title,
                    TeacherId = course.TeacherId,
                    CourseTeacher = course.CourseTeacher,
                    Code = course.Code,
                };
                courseList.Add(ViewModel);
            }

            if (courseList == null) return new List<CourseModel>();
            return courseList;


        }
        public async Task<CourseModel> PrepareCourseByIdAsync(int id)
        {
            var course = await _course.GetCourseByIdAsync(id);

            if (course == null) return new CourseModel();

            CourseModel ViewModel = new CourseModel()
            {
                Id = course.Id,
                Title = course.Title,
                TeacherId = course.TeacherId,
                CourseTeacher = course.CourseTeacher,
            };

            return ViewModel;

        }
        #endregion
    }
}
