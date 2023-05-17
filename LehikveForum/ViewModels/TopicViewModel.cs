using LehikveForum.Models;

namespace LehikveForum.ViewModels
{
    public class TopicViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Header { get; set; }
        public DateTime TimeOfLastMessage { get; set; }
        public int NumberOfMessages { get; set; } = 0;
    }
}
