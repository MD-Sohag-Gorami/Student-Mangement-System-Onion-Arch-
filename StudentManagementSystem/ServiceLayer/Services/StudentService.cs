using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;


namespace Multi_lingual_student_management_system.Services
{
    public class StudentService : IStudentService
    {
        #region Ctor
        private readonly ApplicationDbContext _db;
        private readonly ILocalizationService _localization;
        private readonly ICourseService _courseService;

        public StudentService(ApplicationDbContext db,
                              ILocalizationService localization,
                              ICourseService courseService)
        {
            _db = db;
            _localization = localization;
            _courseService = courseService;
        }
        #endregion
        #region Methods

        public async Task<List<Student>> GetAllStudentAsync()
        {
            var model = _db.Students.ToList();
            if (model == null) return new List<Student>();
            return model;

        }
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var model = _db.Students.Where(x => x.Id == id).Select(y => new Student()
            {
                Id = y.Id,
                Name = y.Name,
                Roll = y.Roll,
                EnrolledCourses = y.EnrolledCourses.Select(z => new Course()
                {
                    Id = z.Id,
                    Title = z.Title,
                    CourseTeacher = z.CourseTeacher
                }).ToList()
            }).FirstOrDefault();
            if (model == null) return new Student();

            return model;
        }
        public async Task UpdateStudentAsync(Student student)
        {

        }
        public async Task DeleteStudentByIdAsync(int id)
        {
            var student = await _db.Students.FindAsync(id);
            if(student!=null)
            {
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();

            }
           
        }
        public async Task InsertStudentAsync(Student student, int language, string translation)
        {
           
            await _db.Students.AddAsync(student);
            await _db.SaveChangesAsync();

            await _localization.InsertLocalizationAsync(language, "Student", student.Id, "Name", translation);
        }
        public async Task<bool> IsEnrolledCourseAsync(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0) return false;
            var course = _db.Courses.Where(x => x.Id == courseId).FirstOrDefault();
            var isEnrolled = _db.Students.Where(x => x.Id == studentId).Select(y => y.EnrolledCourses.Contains(course)).FirstOrDefault();
            return isEnrolled;

        }

        public async Task RemoveEnrolledCourseFromStudentAsync(int courseId, int studentId)
        {
            if (courseId == 0 || studentId == 0) return ;
            var student =  _db.Students.Where(x => x.Id == studentId).FirstOrDefault();

             /* var students = await _db.Students.Where(x => x.Id == studentId).Select(y => new StudentModel()
              {
                  Id = y.Id,
                  EnrolledCourses = y.EnrolledCourses.Select(z => new CourseModel()
                  {
                      Id = z.Id,
                      Title = z.Title,
                      CourseTeacher = z.CourseTeacher

                  }).ToList()


              }).FirstOrDefault();*/

            foreach (var course in student.EnrolledCourses)
            {
                var check = await IsEnrolledCourseAsync(courseId, studentId);
                if(check)
                {
                    student.EnrolledCourses.Clear();
                }
            }
       

           if(student != null && student.EnrolledCourses != null) 
            {
               
                _db.Students.Update(student);
                await _db.SaveChangesAsync();
            }
          
            
        }


        public async Task EnrollCouresToStudenAsync(List<int> enrollCourses, int studentId)
        {
            var student = await _db.Students.FindAsync(studentId);
          
            if (student == null) return;

            var allCourses = await _courseService.GetAllCourseAsync();

            var courseList = new List<Course>();

            foreach (var course in allCourses)
            {
                bool isEnrolledCourse = false;
                isEnrolledCourse = await IsEnrolledCourseAsync(course.Id, studentId);
                if (enrollCourses.Contains(course.Id))
                {
                   
                    if(!isEnrolledCourse) courseList.Add(course);
                }
                else if(isEnrolledCourse)
                {
                    await RemoveEnrolledCourseFromStudentAsync(course.Id, studentId);
                }
            }

            student.EnrolledCourses = courseList;
         
            _db.Students.Update(student);
            await _db.SaveChangesAsync();
        }
        #endregion
    }
}
