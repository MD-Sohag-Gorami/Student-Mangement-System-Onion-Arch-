using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Factories;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;

namespace Multi_lingual_student_management_system.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseModelFactory _courseFactory;
        private readonly ITeacherModelFactory _teacherFactory;
        private readonly ICourseService _courseService;
        private readonly ITeacherService _teacherService;

        public CourseController(ICourseModelFactory courseFactory,
                                ITeacherModelFactory teacherFactory,
                                ICourseService courseService,
                                ITeacherService teacherService)
        {
            
            _courseFactory = courseFactory;
            _teacherFactory = teacherFactory;
            _courseService = courseService;
            _teacherService = teacherService;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _courseFactory.PrepareAllCourseAsync();
            if (model == null) return NotFound();

            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var teachers = await _courseFactory.PrepareCourseModelAsync(new CourseModel());
            if (teachers == null) return NotFound();
         
            return View(teachers);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CourseModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = await _teacherService.GetTeacherByIdAsync(model.TeacherId);
                var course = new Course()
                {
                    Id = model.Id,
                    Title = model.Title,
                    TeacherId = model.TeacherId,
                    CourseTeacher = teacher.Name,
                    Code = model.Code,
                };
                await _courseService.InsertCourseAsync(course);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await _courseService.DeleteCourseByIdAsync(id.Value);
            return RedirectToAction("Index");
        }
    }
    
}
