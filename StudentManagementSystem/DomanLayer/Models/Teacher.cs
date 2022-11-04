using System.ComponentModel.DataAnnotations;

namespace Multi_lingual_student_management_system.Models
{
    public class Teacher
    {
        public Teacher()
        {
            TakenCourses = new List<Course>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Designation { get; set; }
        public IList<Course> TakenCourses { get; set; }

    }
}