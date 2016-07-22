

namespace Coder_Foundry_Portfolio.Migrations
{
using Coder_Foundry_Portfolio;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

internal sealed class Configuration : DbMigrationsConfiguration<Coder_Foundry_Portfolio.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        protected override void Seed(Coder_Foundry_Portfolio.Models.ApplicationDbContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(
            new RoleStore<IdentityRole>(context));
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
            }

            if (!context.Roles.Any(r => r.Name == "Moderator"))
            {
                roleManager.Create(new IdentityRole { Name = "Moderator" });
            }
            var userManager = new UserManager<ApplicationUser>(
           new UserStore<ApplicationUser>(context));
            if (!context.Users.Any(u => u.Email == "rrousseau1988@gmail.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "rrousseau1988@gmail.com",
                    Email = "rrousseau1988@gmail.com",
                    FirstName = "Ryan",
                    LastName = "Rousseau",
                    DisplayName = "RRousseau"
                }, "E@gles1988");
            }

            if (!context.Users.Any(u => u.Email == "jtwitchell@coderfoundry.com"))
            {
                userManager.Create(new ApplicationUser
                {
                    UserName = "jtwitchell@coderfoundry.com",
                    Email = "jtwitchell@coderfoundry.com",
                    FirstName = "Jason",
                    LastName = "Twitchell",
                    DisplayName = "J-Twich"
                }, "Abc&123");
            }


            var userId = userManager.FindByEmail("rrousseau1988@gmail.com").Id;
            userManager.AddToRole(userId, "Admin");

            var juserId = userManager.FindByEmail("jtwitchell@coderfoundry.com").Id;
            userManager.AddToRole(juserId, "Moderator");
        }
    }
}