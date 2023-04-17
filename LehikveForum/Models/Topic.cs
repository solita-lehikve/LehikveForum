using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LehikveForum.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Header { get; set; }
        //public User User { get; set; }
        //public ICollection<Message> Messages { get; set; }

    }
}
