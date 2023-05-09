using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

    }
}
