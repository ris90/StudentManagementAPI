namespace StudentManagementAPI.Models
{
    public class Student
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Gender { get; set; } = string.Empty;
        public int StudentId { get; set; }
        public string Dept { get; set; } = string.Empty;
        public string University { get; set; } = string.Empty;

    }
}
