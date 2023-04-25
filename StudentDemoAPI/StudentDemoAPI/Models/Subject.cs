using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentDemoAPI.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string SubjectName { get; set; } = "";
        public int Credits { get; set; }
    }
}