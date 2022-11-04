using Multi_lingual_student_management_system.Data;
using Multi_lingual_student_management_system.Models;


namespace Multi_lingual_student_management_system.Services
{
    public class TeacherService : ITeacherService
    {

        private readonly ApplicationDbContext _db;
        private readonly ILocalizationService _localizationService;

        public TeacherService(ApplicationDbContext db,
                              ILocalizationService localizationService)
        {
            _db = db;
            _localizationService = localizationService;
        }

        public async Task<List<Teacher>> GetAllTeacherAsync()
        {
            var model = _db.Teachers.ToList();
            if (model == null) return new List<Teacher>();
            return model;

        }
        public async Task<Teacher> GetTeacherByIdAsync(int id)
        {
            var model = await _db.Teachers.FindAsync(id);
            if(model == null) return new Teacher();
            return model;
        }
        public async Task UpdateTeacherAsync(Teacher teacher)
        {

        }
        public async Task DeleteTeacherByIdAsync(int id)
        {
            var teracher = await _db.Teachers.FindAsync(id);
            if (teracher != null)
            {
                _db.Teachers.Remove(teracher);
                await _db.SaveChangesAsync();

            }
        }
        public async Task InsertTeacherAsync(Teacher teacher, int language,string translation)
        {
           
            await _db.Teachers.AddAsync(teacher);
            await _db.SaveChangesAsync();

            await _localizationService.InsertLocalizationAsync(language, "Teacher", teacher.Id, "Name", translation);


        }

    }
}
