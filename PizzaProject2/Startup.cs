//using Microsoft.Owin;
//using Owin;
using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PizzaProject2.Models;

[assembly: OwinStartupAttribute(typeof(PizzaProject2.Startup))]
namespace PizzaProject2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }

        // Creates default user roles and a single admin user 
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
  
            // If admin role does not exist, create it and a single admin user
            if (!roleManager.RoleExists("Admin"))
            {

                // Create admin role 
                //var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                // Create admin user
                var user = new ApplicationUser();
                user.UserName = "admin@gmail.com"; // Admin username
                user.Email = "admin@gmail.com"; // Admin email
                string adminPassword = "aD_min123"; // Admin password, has to meet password requirements!
                var adminUser = UserManager.Create(user, adminPassword);

                //Add default User to Role Admin   
                if (adminUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");
                }
            }
        }
    }
}
