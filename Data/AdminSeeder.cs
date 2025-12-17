using Microsoft.AspNetCore.Identity;
using StudSpa.Data;

public static class AdminSeeder
{
    public static async Task SeedAdminAsync(IServiceProvider services)
    {
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        string adminEmail = "admin@studspa.com";
        string adminPassword = "Admin123!";

        if (!await roleManager.RoleExistsAsync("SpaAdmin"))
            await roleManager.CreateAsync(new IdentityRole("SpaAdmin"));

        var adminUser = await userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                EmailConfirmed = true
            };

            await userManager.CreateAsync(adminUser, adminPassword);
            await userManager.AddToRoleAsync(adminUser, "SpaAdmin");
        }
    }
}

