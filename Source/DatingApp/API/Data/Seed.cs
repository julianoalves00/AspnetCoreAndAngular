using API.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUser(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            // Read seed users file
            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            if (users == null)
                return;

            // Create roles
            var roles = new List<AppRole>
            {
                new AppRole{ Name = Constants.ROLE_MEMBER},
                new AppRole{ Name = Constants.ROLE_ADMIN},
                new AppRole{ Name = Constants.ROLE_MODERATOR}
            };


            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            // Create admin user
            var admin = new AppUser
            {
                UserName = Constants.ADMIN_USER
            };

            await userManager.CreateAsync(admin, Constants.DEFAULT_PASSWORD);
            await userManager.AddToRolesAsync(admin, new[] { Constants.ROLE_ADMIN, Constants.ROLE_MODERATOR });

            // Create seed users
            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, Constants.DEFAULT_PASSWORD);
                await userManager.AddToRoleAsync(user, Constants.ROLE_MEMBER);
            }
        }
    }
}
