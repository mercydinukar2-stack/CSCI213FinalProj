using Microsoft.AspNetCore.Identity;
using StudSpa.Models;

namespace StudSpa.Data
{
    public static class EmployeeSeeder
    {
        public static async Task SeedEmployeeAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            const string employeeEmail = "employee@studspa.com";
            const string employeePassword = "Employee123!";
            const string employeeRole = "ServiceProvider";

            // Ensure role exists
            if (!await roleManager.RoleExistsAsync(employeeRole))
            {
                await roleManager.CreateAsync(new IdentityRole(employeeRole));
            }

            // Ensure employee user exists
            var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
            if (employeeUser == null)
            {
                employeeUser = new ApplicationUser
                {
                    UserName = employeeEmail,
                    Email = employeeEmail,
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(employeeUser, employeePassword);
                if (!result.Succeeded)
                    throw new Exception("Failed to create employee user");
            }

            // Assign role
            if (!await userManager.IsInRoleAsync(employeeUser, employeeRole))
            {
                await userManager.AddToRoleAsync(employeeUser, employeeRole);
            }
        }
    }
}

