using System.ComponentModel.DataAnnotations;

namespace Student_Task.Models
{
    public class Student
    {
        public int ID { set; get; }
        [Required]
        public string? FullName { set; get; }
        [Required]
        public string? ClassLevel { set; get; }
        [Required]
        public string? Status { set; get; }
        public DateTime BirthDate { set; get; }
        public string? Address { set; get; }
    }
}
