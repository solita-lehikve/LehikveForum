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

        public IList<Topic> GetAll()
        {
            return _context.Topics
                .Include(m => m.Messages)
                .ToList();
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
