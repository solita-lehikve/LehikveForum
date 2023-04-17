using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Role { get; set; }
        //public ICollection<Topic> Topic { get; set; }
        //public ICollection<Message> Message { get; set; }
    }
}
