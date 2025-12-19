using Microsoft.AspNetCore.Identity;
using StudSpa.Data;

namespace StudSpa.Data
{
    public static class EmployeeSeeder
    {
        public static async Task SeedEmployeeAsync(IServiceProvider services)
        {
            var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            const string employeeRole = "ServiceProvider";

            // Ensure role exists
            if (!await roleManager.RoleExistsAsync(employeeRole))
            {
                await roleManager.CreateAsync(new IdentityRole(employeeRole));
            }

            // List of employees to seed
            var employees = new[]
            {
                new { Email = "sara@studspa.com", Password = "Employee123!", FirstName = "Sarah", LastName = "Johnson" },
                new { Email = "michael@studspa.com", Password = "Employee123!", FirstName = "Michael", LastName = "Chen" },
                new { Email = "jessica@studspa.com", Password = "Employee123!", FirstName = "Jessica", LastName = "Martinez" },
                new { Email = "david@studspa.com", Password = "Employee123!", FirstName = "David", LastName = "Williams" }
            };

            foreach (var emp in employees)
            {
                var employeeUser = await userManager.FindByEmailAsync(emp.Email);
                if (employeeUser == null)
                {
                    employeeUser = new ApplicationUser
                    {
                        UserName = emp.Email,
                        Email = emp.Email,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(employeeUser, emp.Password);
                    if (!result.Succeeded)
                        throw new Exception($"Failed to create employee user {emp.Email}");
                }

                // Assign role
                if (!await userManager.IsInRoleAsync(employeeUser, employeeRole))
                {
                    await userManager.AddToRoleAsync(employeeUser, employeeRole);
                }
            }
        }
    }
}

