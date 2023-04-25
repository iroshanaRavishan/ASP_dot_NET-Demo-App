using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentDemoAPI.Models
{
    public class Enrolment
    {
        [Key]
        public int EnrolmetId { get; set; }

        [Required]
        public int StudentId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        public DateTime EnrolmetDate { get; set; }
        public virtual ICollection<Student>? Students { get; set; }
    }
}
