using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
namespace Multi_lingual_student_management_system.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly ApplicationDbContext _db;

        public LanguageService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Language>> GetAllLanguageAsync()
        {
            var languages = _db.Languages.ToList();
         

            return languages;

        }
        public async Task<Language> GetLanguageByIdAsync(int? id)
        {
            return new Language();
        }
        public async Task UpdateLanguageAsync(Language language)
        {

        }
        public async Task DeleteLanguageByIdAsync(int? id)
        {
            var language = await _db.Languages.FindAsync(id);
            if (language != null)
            {
                _db.Languages.Remove(language);
                await _db.SaveChangesAsync();

            }
        }
        public async Task CreateLanguageAsync(Language language)
        {
         
            await _db.Languages.AddAsync(language);
            await _db.SaveChangesAsync();
        }
        public async Task SetDefaultLanguaeAsync(int id)
        {
            var language = await _db.Languages.FindAsync(id);
            var languages = await GetAllLanguageAsync();

            for(int i = 0; i < languages.Count; i++)
            {
                var update = await _db.Languages.FindAsync(languages[i].Id);

                 update.IsDefault = false;
                _db.Languages.Update(update);
                await _db.SaveChangesAsync();

            }

            if (language!= null)
            {
                language.IsDefault = true;
                _db.Languages.Update(language);
                await _db.SaveChangesAsync();
            }
           

        }

    }
}
