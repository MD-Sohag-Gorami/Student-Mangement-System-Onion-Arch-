
using Multi_lingual_student_management_system.Models;

namespace Multi_lingual_student_management_system.Services
{
    public interface ILanguageService
    {
        Task DeleteLanguageByIdAsync(int? id);
        Task<List<Language>> GetAllLanguageAsync();
        Task<Language> GetLanguageByIdAsync(int? id);
        Task UpdateLanguageAsync(Language language);
        Task CreateLanguageAsync(Language language);
        Task SetDefaultLanguaeAsync(int id);
    }
}