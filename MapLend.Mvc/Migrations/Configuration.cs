namespace MapLend.Mvc.Migrations
{
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using Business;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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


            // Catégories d'outils
            Category cat = new Category { Name = "Petits outils" };
            context.Categories.AddOrUpdate(c => c.Name, cat);

            // Status des outils
            ToolStatus ts = new ToolStatus { Name = "Disponible" };
            context.ToolStatuses.AddOrUpdate(s => s.Name, ts);

            // Addresses
            Address user1Address = new Address { Id = 1, AddressLine1 = "19 rue du 8 mai 1945", City = "Arcueil", Country = "France", ZipCode = "94110" };
            Address user2Address = new Address { Id = 2, AddressLine1 = "11 rue du 8 mai 1945", City = "Arcueil", Country = "France", ZipCode = "94110" };
            Address user3Address = new Address { Id = 3, AddressLine1 = "4 rue Paul Signac", City = "Arcueil", Country = "France", ZipCode = "94110" };

            Address map1Address = new Address { Id = 4, AddressLine1 = "19 rue du 8 mai 1945", City = "Arcueil", Country = "France", ZipCode = "94110" };

            context.Addresses.AddOrUpdate(a => a.Id, user1Address, user2Address, user3Address, map1Address);

            // Utilisateur Map
            User mapUser1 = new User { Address = user1Address, Firstname = "Riri", Surname = "Duck", Rating = 3, Username = "user1@toto.fr", Tools = new List<Tool> { new Tool { Id = 1, Category = cat, ToolStatus = ts, Name = "Marteau" } } };
            User mapUser2 = new User { Address = user2Address, Firstname = "Fifi", Surname = "Duck", Rating = 3, Username = "user2@toto.fr" };
            User mapUser3 = new User { Address = user3Address, Firstname = "Loulou", Surname = "Duck", Rating = 3, Username = "user3@toto.fr", Tools = new List<Tool> { new Tool { Id = 2, Category = cat, ToolStatus = ts, Name = "Tournevis" } } };

            context.MapUsers.AddOrUpdate(u => u.Username, mapUser1, mapUser2, mapUser3);

            // Map
            Map firstMap = new Map { Address = map1Address, Name = "Ma première Map", Users = new List<User> { mapUser1, mapUser2, mapUser3 } };
            context.Maps.AddOrUpdate(m => m.Name, firstMap);

            // User (login)
            var store = new UserStore<ApplicationUser>(context);
            var manager = new UserManager<ApplicationUser>(store);
            var appUser1 = new ApplicationUser { UserName = "user1@toto.fr", User = mapUser1 };
            manager.Create(appUser1, "Password@123");

            var appUser2 = new ApplicationUser { UserName = "user2@toto.fr", User = mapUser2 };
            manager.Create(appUser2, "Password@123");

            var appUser3 = new ApplicationUser { UserName = "user3@toto.fr", User = mapUser3 };
            manager.Create(appUser3, "Password@123");
        }
    }
}