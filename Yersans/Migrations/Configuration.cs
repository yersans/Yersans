namespace Yersans.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Web;
    internal sealed class Configuration : DbMigrationsConfiguration<Yersans.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Yersans.Models.ApplicationDbContext";
        }

        protected override void Seed(Yersans.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            
            var userManager = context.Users;
            var roleManager = context.Roles;
            const string name = "yersans@qq.com";
            //const string password = "Test_2016";
            const string roleName = "Admin";

            var role = new IdentityRole(roleName);
            if (roleManager.Any(r => r.Name == roleName) == false)
            {
                var roleResult = roleManager.Add(role);
            }

            var user = userManager.Single(u => u.UserName == name);
            var userRole = new IdentityUserRole { UserId = user.Id, RoleId = role.Id };
            
            if (!user.Roles.Contains(userRole))
            {
                user.Roles.Add(userRole);
            }
        }
    }
}
