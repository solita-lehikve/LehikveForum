using DiscussionForum.Models;
using Microsoft.EntityFrameworkCore;

namespace DiscussionForum.Data
{
    public class DiscussionForumContext : DbContext
    {
        public DiscussionForumContext(DbContextOptions<DiscussionForumContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
