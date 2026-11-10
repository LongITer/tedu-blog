using Microsoft.AspNetCore.Identity;
using TeduBlog.Core.Domain.Identity;

namespace TeduBlog.Data
{
    public class DataSeeder
    {
        public async Task SeedAsync(TeduBlogContext context)
        {
            var passwordHasher = new PasswordHasher<AppUser>();

            var rootAdminRole = Guid.NewGuid();

            if (!context.Roles.Any())
            {
                await context.Roles.AddAsync(new AppRole()
                {
                    Id = rootAdminRole,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    DisplayName = "Quản trị viên"
                });
                await context.SaveChangesAsync();

            }
            if (!context.Users.Any())
            {
                var userId = Guid.NewGuid();
                var user = new AppUser()
                {
                    Id = userId,
                    FirstName = "Toan",
                    LastName = "Nguyen",
                    Email = "toan123@gmail.com",
                    NormalizedEmail = "TOAN123@GMAIL.COM",
                    UserName = "toan123",
                    NormalizedUserName = "TOAN123",
                    IsActive = true,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    LockoutEnabled = false,
                    DateCreated = DateTime.Now
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "admin123");
                await context.Users.AddAsync(user);

                await context.UserRoles.AddAsync(new IdentityUserRole<Guid>()
                {
                    RoleId = rootAdminRole,
                    UserId = userId
                });

                await context.SaveChangesAsync();

            }
        }
    }
}
