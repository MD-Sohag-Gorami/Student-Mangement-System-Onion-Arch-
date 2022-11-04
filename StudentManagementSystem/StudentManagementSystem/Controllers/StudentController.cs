using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class StudentController : Controller
    {
        #region Ctro
        private readonly ILanguageService _language;
        private readonly IStudentModelFactory _studentFactory;
        private readonly ICourseService _course;
        private readonly IStudentService _student;

        public StudentController(ILanguageService language,
                               
                                 IStudentService student, 
                                 IStudentModelFactory studentFactory,
                                 ICourseService course)
        {
            _language = language;
           
            _student = student;
            _studentFactory = studentFactory;
            _course = course;
        }
        #endregion
        #region Methods
        public async Task<IActionResult> Index()
        {
            var model = await _studentFactory.PrepareAllStudentAsync();
            if(model == null) return NotFound();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {

            var studentView = await _studentFactory.PrepareStudentModelAsync(new StudentModel());
            if(studentView == null) return NotFound();

            return View(studentView);
        }
        [HttpPost]
        public async Task<IActionResult> Create(StudentModel student)
        {
            if(ModelState.IsValid)
            {
                Student student1 = new Student();
                student1.Id = student.Id;
                student1.Name = student.Name;
                student1.Roll = student.Roll;
                await _student.InsertStudentAsync(student1, student.Language, student.Translation);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if(id == null || id == 0) return NotFound();
            var model = await _studentFactory.PrepareStudentByIdAsync(id.Value);
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult>  EnrollCourse(int id)
        {

            var courseList = await _course.GetAllCourseAsync();
            if(courseList == null) return NotFound();
            List<EnrollCourseModel> enrollCourse = new List<EnrollCourseModel>();
            foreach (var course in courseList)
            {
                var viewModel=(new EnrollCourseModel()
                {
                    CourseId = course.Id,
                    CourseCode = course.Code,
                    CourseTeacher = course.CourseTeacher,
                    CourseTitle = course.Title,
                });

                var check = await _student.IsEnrolledCourseAsync(course.Id, id);
                if (check)
                {
                    viewModel.IsSelected = true;
                }
                else viewModel.IsSelected = false;
                enrollCourse.Add(viewModel);
                
            }
            ViewBag.studentId = id;
            return View(enrollCourse);
        }
        [HttpPost]
        public async Task<IActionResult> EnrollCourse(int id,List<EnrollCourseModel> enrollCourses)
        {
            var selectedCourseIds = enrollCourses.Where(x => x.IsSelected).Select(y => y.CourseId).ToList();
            await _student.EnrollCouresToStudenAsync(selectedCourseIds, id);
            return RedirectToAction("Detail", new { id = id });

        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();
            await _student.DeleteStudentByIdAsync(id.Value);
            return RedirectToAction("Index");
        }

        #endregion
    }
}
