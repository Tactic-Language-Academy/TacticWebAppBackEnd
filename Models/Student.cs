namespace TacticWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; } = string.Empty; // ✅ Default value to avoid warning
    }
}
