using Microsoft.AspNetCore.Mvc;
using Multi_lingual_student_management_system.Services;

namespace Multi_lingual_student_management_system.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly ILocalizationService _localizationService;
        #region Ctor
        public LocalizationController(ILocalizationService localizationService)
        {
            _localizationService = localizationService;
        }
        #endregion
        #region Methods
        
        public async Task<IActionResult> Index(int id = 0)
        {
            var model = await _localizationService.GetAllLocalizationAsync(id);
            return View(model);
        }
        #endregion
    }
}