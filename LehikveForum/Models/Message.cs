using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        public Topic Topic { get; set; }
        //public User User { get; set; }

    }
}
