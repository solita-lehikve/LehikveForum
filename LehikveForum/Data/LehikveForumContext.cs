using LehikveForum.Models;
using Microsoft.EntityFrameworkCore;

namespace LehikveForum.Data
{
    public class LehikveForumContext : DbContext
    {
        public LehikveForumContext(DbContextOptions<LehikveForumContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
