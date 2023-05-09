using LehikveForum.Data;
using Microsoft.EntityFrameworkCore;

namespace LehikveForum.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new LehikveForumContext(
                serviceProvider.GetRequiredService<DbContextOptions<LehikveForumContext>>()))
            {

                if (context.Users.Any())
                {
                    return;
                }

                var users = new User[]
                {
                    new User{Username = "Topi", Role = "admin"},
                    new User{Username = "Pekka", Role = "user"}
                };


                foreach (User u in users)
                {
                    context.Users.Add(u);
                }
                context.SaveChanges();

                var topics = new Topic[]
                {
                    new Topic{Header = "Suomalaiset nimet", User = users[0]},
                    new Topic{Header = "Automerkit", User = users[1]}
                };

                foreach (Topic topic in topics)
                {
                    context.Topics.Add(topic);
                };
                context.SaveChanges();

                context.Messages.AddRange(
                    new Message
                    {
                        Text = "Kati",
                        Topic = topics[0],
                        CreatedDateTime = DateTime.Now.AddDays(-1),
                        User = users[0]

                    },
                    new Message
                    {
                        Text = "Topi",
                        Topic = topics[0],
                        CreatedDateTime = DateTime.Now.AddDays(-2),
                        User = users[0]
                    },
                    new Message
                    {
                        Text = "Ville",
                        Topic = topics[0],
                        CreatedDateTime = DateTime.Now.AddDays(-3),
                        User = users[0]
                    },
                    new Message
                    {
                        Text = "Volkswagen",
                        Topic = topics[1],
                        CreatedDateTime = DateTime.Now.AddDays(-4),
                        User = users[0]
                    });

                context.SaveChanges();
            }
        }
    }
}
