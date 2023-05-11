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
        [ForeignKey("UserId")]
        public User User { get; set; }
        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
