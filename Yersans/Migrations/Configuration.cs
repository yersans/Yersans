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
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            const string name = "yersans@126.com";
            const string password = "Test_2016";
            const string roleName = "Guest";

            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new ApplicationUser { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                userManager.AddToRole(user.Id, role.Name);
            }
            
            string adminUserName = "yersans@qq.com";
            string adminRoleName = "Admin";

            var admin = userManager.FindByName(adminUserName);
            if (admin != null)
            {
                var adminRole = roleManager.FindByName(adminRoleName);
                if (adminRole == null)
                {
                    roleManager.Create(new IdentityRole(adminRoleName));
                }

                var rolesForAdmin = userManager.GetRoles(admin.Id);
                if (!rolesForAdmin.Contains(adminRoleName))
                {
                    userManager.AddToRoles(admin.Id, adminRole.Name);
                }
            }
        }
    }
}
