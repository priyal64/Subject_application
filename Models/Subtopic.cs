using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace v_try.Models
{
    public class Subtopic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SubtopicName { get; set; }

        [Required]
        [ForeignKey("Topic")]
        public int TopicId { get; set; }

        public Topic Topic { get; set; }
    }
}
