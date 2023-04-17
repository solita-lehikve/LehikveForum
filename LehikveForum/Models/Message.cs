using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
        [ForeignKey("TopicRefId")]
        public Topic Topic { get; set; }
        [ForeignKey("UsersRefId")]
        public User User { get; set; }

    }
}
