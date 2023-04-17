using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiscussionForum.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Header { get; set; }
        [ForeignKey("UsersRefId")]
        public User User { get; set; }
        public ICollection<Message> Message { get; set; }

    }
}
