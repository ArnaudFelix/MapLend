namespace MapLend.Mvc.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Business;
    using Microsoft.AspNet.Identity;
    using Models;
    internal sealed class Configuration : DbMigrationsConfiguration<MapLend.Mvc.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
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

            User alain = new User { Firstname = "Alain", Surname = "Bastardie", Username = "abastardie" };
            context.MapUsers.AddOrUpdate(u => u.Username, alain);

            var passwordHash = new PasswordHasher();
            string password = passwordHash.HashPassword("Password@123");
            context.Users.AddOrUpdate(u => u.UserName,
                new ApplicationUser
                {
                    UserName = "abastardie",
                    PasswordHash = password,
                    User = alain
                });

            Map myFirstMap = new Map { Name = "My first map", Users = new List<User> { alain } };
            context.Maps.AddOrUpdate(m => m.Name, myFirstMap);
        }
    }
}
