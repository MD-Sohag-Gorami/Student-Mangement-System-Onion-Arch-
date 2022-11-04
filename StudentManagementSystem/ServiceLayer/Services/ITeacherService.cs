using Multi_lingual_student_management_system.Models;
namespace Multi_lingual_student_management_system.Services
{
    public interface ITeacherService
    {
        Task InsertTeacherAsync(Teacher teacher, int language,string translation);
        Task DeleteTeacherByIdAsync(int id);
        Task<List<Teacher>> GetAllTeacherAsync();
        Task<Teacher> GetTeacherByIdAsync(int id);
        Task UpdateTeacherAsync(Teacher teacher);
    }
}