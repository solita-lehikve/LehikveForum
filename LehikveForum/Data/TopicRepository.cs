using LehikveForum.Models;
using LehikveForum.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace LehikveForum.Data
{
    public class TopicRepository : ITopicRepository
    {
        private readonly LehikveForumContext _context;

        public TopicRepository(LehikveForumContext context) { 
            _context = context;
        }

        public IList GetAll()
        {
            return _context.Topics
                .Include(m => m.Messages)
                .Select(t => new TopicViewModel
                {
                    Id = t.Id,
                    UserId = t.UserId,
                    Header = t.Header,
                    TimeOfLastMessage = t.Messages
                    .OrderBy(p => p.CreatedDateTime)
                    .Last()
                    .CreatedDateTime,
                    NumberOfMessages = t.Messages.Count()
                }).ToList();
        }

        public void Create(Topic topic)
        {
            throw new NotImplementedException();
        }

        public Topic GetTopic(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(Topic topic)
        {
            throw new NotImplementedException();
        }

        public void Edit(Topic topic)
        {
            throw new NotImplementedException();
        }
    }
}
