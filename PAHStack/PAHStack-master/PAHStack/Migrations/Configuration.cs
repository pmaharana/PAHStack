namespace PAHStack.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using PAHStack.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<PAHStack.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PAHStack.Models.ApplicationDbContext context)
        {
            var patron = "patron";
            var admin = "admin";

            var store = new RoleStore<IdentityRole>(context);
            var manager = new RoleManager<IdentityRole>(store);

            if(!context.Roles.Any(a=>a.Name == patron))
            {
                var role = new IdentityRole { Name = patron };
                manager.Create(role);
            }
            if (!context.Roles.Any(a => a.Name == admin))
            {
                var role = new IdentityRole { Name = admin };
                manager.Create(role);
            }

            var defaultAdmin = "admin@tiy.com";
            var password = "Password1!";

            if(!context.Users.Any(a => a.UserName == defaultAdmin))
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var user = new ApplicationUser { UserName = defaultAdmin };

                userManager.Create(user, password);
                userManager.AddToRole(user.Id, admin);
            }
        }
    }
}
