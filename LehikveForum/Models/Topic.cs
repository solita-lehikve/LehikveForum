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
        [StringLength(50), MinLength(2)]
        public string Header { get; set; } = null!;
        [ForeignKey("UserId")]
        public User User { get; set; } = new User();
        public int UserId { get; set; }
        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
