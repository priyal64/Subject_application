using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v_try.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string TopicName { get; set; }

        [Required]
        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public ICollection<Subtopic> Subtopics { get; set; } = new List<Subtopic>();
    }
}
