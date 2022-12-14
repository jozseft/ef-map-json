namespace MapJSON.Data.Entities
{
    public class UserSettings
    {
        public string Language { get; set; }
        public Theme Theme { get; set; }
        public ICollection<TableDisplayedColumns>? Tables { get; set; }
    }
}
