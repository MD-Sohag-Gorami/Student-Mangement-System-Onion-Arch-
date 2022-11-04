using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;
namespace Multi_lingual_student_management_system.Services
{
    public class LocalizationService : ILocalizationService
    {

        private readonly ApplicationDbContext _db;


        public LocalizationService(ApplicationDbContext db
                             )
        {
            _db = db;

        }

        public async Task<List<Localization>> GetAllLocalizationAsync(int languageId = 0)
        {
            var model = _db.Localizations.ToList();
            if(languageId > 0)
            {
                model = _db.Localizations.Where(x => x.Language.Id == languageId).ToList();
            }
            return model;

        }
        public async Task<Localization> GetLocalizationByIdAsync(int languageId = 0, string entityName ="", int entityId = 0, string name="")
        {
            if(languageId ==0) return new Localization();
            var localization = _db.Localizations.Where(x => x.LanguageId == languageId).FirstOrDefault();

            if (languageId > 0 && entityId > 0 && entityName != null && name!=null)
            {
               localization=  _db.Localizations.Where(x => x.LanguageId == languageId && x.EntityId == entityId && x.EntityName == entityName && x.EntityPropertyName==name).FirstOrDefault();
            }
            
            return localization;
        }
        public async Task UpdateLocalizationAsync(Localization model)
        {

        }
        public async Task DeleteLocalizationByIdAsync(int id)
        {

        }
        public async Task InsertLocalizationAsync(int languageId = 0, string entityName = "",
                                                    int entityId = 0, string propertyName = "",
                                                    string value = "")
        {

            var model = new Localization()
            {

                EntityName = entityName,
                EntityId = entityId,
                EntityPropertyName = propertyName,
                Value = value,
                LanguageId = languageId
            };

            await _db.Localizations.AddAsync(model);
            await _db.SaveChangesAsync();
        }

    }
}
