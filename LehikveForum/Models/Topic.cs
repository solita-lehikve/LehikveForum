using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class Topic
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        public DateTime TimeOfLastMessage { get; set; }
        public int NumberOfMessages { get; set; } = 0;
        [ForeignKey("UserId")]
        public User User { get; set; }
        public ICollection<Message>? Messages { get; set; } = new List<Message>();
    }
}
