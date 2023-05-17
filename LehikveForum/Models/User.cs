using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100), MinLength(2)]
        public string Username { get; set; } = null!;
        [Required]
        [StringLength(50), MinLength(2)]
        public string Role { get; set; } = null!;
        public IList<Topic> Topics { get; set; } = new List<Topic>();
        public IList<Message> Messages { get; set; } = new List<Message>();
    }
}
