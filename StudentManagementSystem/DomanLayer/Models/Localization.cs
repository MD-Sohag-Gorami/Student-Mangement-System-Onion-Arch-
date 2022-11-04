namespace Multi_lingual_student_management_system.Models
{
    public class Localization
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public virtual Language Language  { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string EntityPropertyName { get; set; }
        public string Value { get; set; }
    }
}
