using CBA.Core.Models;
using CBA.Core.Enums;
using CBA.DAL.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL
{
    public class AppUserSeedData
    {

        public static async Task Initialize(AppDbContext context,
                              UserManager<ApplicationUser> userManager,
                              RoleManager<ApplicationRole> roleManager)
        {
            context.Database.EnsureCreated();

            String adminId = "";

            string role = "Admin";
            Status? status = Status.Enabled;


            string password = "P@$$w0rd";

            if (await roleManager.FindByNameAsync(role) == null)
            {
                await roleManager.CreateAsync(new ApplicationRole(role, status));
            }

            if (await userManager.FindByNameAsync("aa@aa.aa") == null)
            {
                var user = new ApplicationUser
                {
                    UserName = "boluwatifeoyetoro@gmail.com",
                    Email = "boluwatifeoyetoro@gmail.com",
                    FirstName = "Boluwatife",
                    LastName = "Oyetoro",
                    Gender = Core.Enums.Gender.Male,
                    Status = Core.Enums.Status.Enabled
                };

                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, role);
                }
                adminId = user.Id;
            }

        }
    }
}
