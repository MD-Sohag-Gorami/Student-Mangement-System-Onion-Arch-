using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.Models
{
    public class Student
    {
        public Student()
        {
            EnrolledCourses = new List<Course> ();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public IList<Course>? EnrolledCourses { get; set; }

    }
}
