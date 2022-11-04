using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Multi_lingual_student_management_system.Models;
using Multi_lingual_student_management_system.Services;
using Multi_lingual_student_management_system.ViewModel;
using System.Diagnostics;

namespace Multi_lingual_student_management_system.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILanguageService _language;
        private readonly ILocalizationService _localizationService;

        public HomeController(ILogger<HomeController> logger,
                              ILanguageService language
                              )
        {
            _logger = logger;
            _language = language;
          
        }
        public async Task<IActionResult> Index()
        {
            var languages = await _language.GetAllLanguageAsync();
            ViewBag.languages = new SelectList(languages, "Id", "Name");
            return View(new DefaultLanguageModel());

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}