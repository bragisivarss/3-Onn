using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        public ICollection<Mark> Marks { get; set; }

        public List<Teacher> Teachers { get; set; } = new List<Teacher>();
    }
}
