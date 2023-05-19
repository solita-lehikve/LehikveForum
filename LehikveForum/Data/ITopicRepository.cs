using LehikveForum.Models;
using System.Collections;

namespace LehikveForum.Data
{
    public interface ITopicRepository
    {
        public void Create(Topic topic);
        public void Edit(Topic topic);
        public void Delete(Topic topic);
        public IList<Topic> GetAll();
        public Topic GetTopic(int id);
         
    }
}
