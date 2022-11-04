
using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;

namespace Multi_lingual_student_management_system.Services
{
    public class CourseService : ICourseService
    {

        private readonly ApplicationDbContext _db;
        private readonly ITeacherService _teacher;

        public CourseService(ApplicationDbContext db,
                             ITeacherService teacher)
        {
            _db = db;
            _teacher = teacher;
        }

        public async Task<List<Course>> GetAllCourseAsync(int teacherId = 0)
        {
            var model = _db.Courses.ToList();
            if(teacherId > 0)
            {
                model = model.Where(teacher => teacher.TeacherId == teacherId).ToList();
            }

            return model;

        }
        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return new Course();
        }
        public async Task DeleteCourseByIdAsync(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();

            }
        }
        public async Task InsertCourseAsync(Course course)
        {
           
          
            await _db.Courses.AddAsync(course);
            await _db.SaveChangesAsync();
        }

    }
}
