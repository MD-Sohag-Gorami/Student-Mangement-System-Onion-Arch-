using Multi_lingual_student_management_system.Models;

namespace Multi_lingual_student_management_system.Services
{
    public interface ILocalizationService
    {
        Task DeleteLocalizationByIdAsync(int id);
        Task<List<Localization>> GetAllLocalizationAsync(int languageId = 0);
        Task<Localization> GetLocalizationByIdAsync(int languageId = 0, string entityName = "", int entityId = 0, string name="");
        Task InsertLocalizationAsync(int languageId = 0, string entityName = "", int entityId = 0, string propertyName = "", string value = "");
        Task UpdateLocalizationAsync(Localization model);
    }
}