using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v_try.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SubjectName { get; set; }

        public ICollection<Topic> Topics { get; set; } = new List<Topic>();
    }
}
