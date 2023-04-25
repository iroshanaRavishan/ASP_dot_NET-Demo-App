using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDemoAPI.Models
{
    public class Student
    {
        // auto mapper
        [Key]
        public int StudentId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; } = "";
        public int ContactNumber { get; set;}
        public int Age { get; set;}
    }
}
