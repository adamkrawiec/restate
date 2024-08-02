using restate.RealEstateManagement.Models;

namespace restate.db.Seeds;

public class Users
{
    public static void Seed(AppDbContext context)
    {
        if (context.Users.Any())
        {
            return;
        }

        context.Users.AddRange(
            new User
            {
                Email = "user1@example.com"
            },
            new User
            {
                Email = "user2@example.com"
            },
            new User
            {
                Email = "user3@example.com"
            }
        );
        context.SaveChanges();
    }
}
  