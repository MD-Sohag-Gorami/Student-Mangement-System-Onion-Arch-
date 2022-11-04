using Multi_lingual_student_management_system.Models;


namespace Multi_lingual_student_management_system.Services
{
    public interface ICourseService
    {
        Task InsertCourseAsync(Course course);
        Task DeleteCourseByIdAsync(int id);
        Task<List<Course>> GetAllCourseAsync(int teacherId = 0);
        Task<Course> GetCourseByIdAsync(int id);
   
    }
}