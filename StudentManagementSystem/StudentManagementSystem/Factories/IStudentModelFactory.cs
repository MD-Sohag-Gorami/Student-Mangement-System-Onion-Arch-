using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Factories
{
    public interface IStudentModelFactory
    {
        Task<List<StudentModel>> PrepareAllStudentAsync();
        Task<StudentModel> PrepareStudentByIdAsync(int id);
        Task<StudentModel> PrepareStudentModelAsync(StudentModel viewModel);
    }
}