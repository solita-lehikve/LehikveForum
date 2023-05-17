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
        [StringLength(200), MinLength(2)]
        public string Text { get; set; } = null!;
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [ForeignKey("TopicId")]
        public Topic Topic { get; set; } = new Topic();
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();

    }
}
