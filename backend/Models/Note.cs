namespace UkrMobilServiceNotes.Models
{
    public class Note
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserProduct { get; set; }
        public DateTime? UserDate { get; set; }
    }
}