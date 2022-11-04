using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;
namespace Multi_lingual_student_management_system.Controllers
{
    public class LanguageController : Controller
    {
        private readonly ILanguageService _language;

        public LanguageController(ILanguageService language)
        {
            _language = language;
        }
        public async Task<IActionResult> Index()
        {
            var model = await _language.GetAllLanguageAsync();
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(LanguageModel model)
        {
            if(ModelState.IsValid)
            {
                Language language = new Language(); 
                language.Name = model.Name;
                language.Id = model.Id;
                language.IsDefault = model.IsDefault;
               
                await _language.CreateLanguageAsync(language);
                return RedirectToAction("Index");
            }
            
            return View(model);
        }
        [HttpGet]
        public async Task<IActionResult> Check(int? id)
        {

            await _language.SetDefaultLanguaeAsync(id.Value);
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            await _language.DeleteLanguageByIdAsync(id.Value);
            return RedirectToAction("Index");
        }
    }
}
