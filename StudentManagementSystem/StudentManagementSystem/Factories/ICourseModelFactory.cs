using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public interface ICourseModelFactory
    {
        Task<List<CourseModel>> PrepareAllCourseAsync();
        Task<CourseModel> PrepareCourseModelAsync(CourseModel viewModel);
        Task<CourseModel> PrepareCourseByIdAsync(int id);
    }
}