

using Multi_lingual_student_management_system.Models;

namespace Multi_lingual_student_management_system.Services
{
    public interface IStudentService
    {
        Task InsertStudentAsync(Student student, int language, string translation);
        Task DeleteStudentByIdAsync(int id);
        Task<List<Student>> GetAllStudentAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task<bool> IsEnrolledCourseAsync(int courseId, int studentId);
        Task EnrollCouresToStudenAsync(List<int> enrollCourses, int id);
        Task RemoveEnrolledCourseFromStudentAsync(int courseId, int studentId);
    }
}