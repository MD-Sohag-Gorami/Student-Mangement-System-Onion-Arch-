using Multi_lingual_student_management_system.ViewModel;
namespace Multi_lingual_student_management_system.Factories
{
    public interface ITeacherModelFactory
    {
        Task<List<TeacherModel>> PrepareAllTeacherAsync();
        Task<TeacherModel> PrepareTeacherByIdAsync(int id);
        Task<TeacherModel> PrepareTeacherModelAsync(TeacherModel viewModel);
    }
}