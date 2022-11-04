using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.Models
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int TeacherId { get; set; }
        public string? CourseTeacher { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public IList<Student>? Students{ get; set; }


    }
}