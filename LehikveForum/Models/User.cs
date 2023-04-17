using System.ComponentModel.DataAnnotations;

namespace DiscussionForum.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public ICollection<Topic> Topic { get; set; }
        public ICollection<Message> Message { get; set; }
    }
}
