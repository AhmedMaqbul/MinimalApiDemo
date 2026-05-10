using MinimalApiDemo.Models;

namespace MinimalApiDemo.Data;

public class UserDataSeeder
{
    public static List<User> GetInitialUsers()
    {
        return
        [
            new User(Guid.Parse("11111111-1111-1111-1111-111111111111"), "Maqbul", "maqbul@gmail.com"),
            new User(Guid.Parse("22222222-2222-2222-2222-222222222222"), "Ahmed", "ahmed@gmail.com")
        ];
    }
}
