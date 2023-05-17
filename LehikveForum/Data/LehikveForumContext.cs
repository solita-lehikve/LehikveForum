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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var foreignKey in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.NoAction;
            }
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
