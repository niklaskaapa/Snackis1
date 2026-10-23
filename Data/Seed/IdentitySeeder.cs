using Microsoft.AspNetCore.Identity;

namespace Snackis1.Data.Seed
{
    
    public static class IdentitySeeder
    {
        public static async Task SeedAdminAsync(WebApplication app)     // Om admin@admin.com finns så sätts denna till Admin rollen. Denna har jag fått AI hjälp med
        {
            using var scope = app.Services.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            const string adminRole = "Admin";
            const string adminEmail = "admin@admin.com"; 

            if (!await roleManager.RoleExistsAsync(adminRole))
            {
                await roleManager.CreateAsync(new IdentityRole(adminRole));
            }

            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser != null && !await userManager.IsInRoleAsync(adminUser, adminRole))
            {
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }
    }
}
