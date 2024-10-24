using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Mark
    {
        [Key]
        public int MarkId { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(0, 100)]
        public int Value { get; set; }

        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
