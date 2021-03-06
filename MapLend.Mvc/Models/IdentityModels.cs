﻿using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using MapLend.Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MapLend.Mvc.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant plus de propriétés à votre classe ApplicationUser ; consultez http://go.microsoft.com/fwlink/?LinkID=317594 pour en savoir davantage.
    public class ApplicationUser : IdentityUser
    {
        public User User { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
#if DEBUG
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> MapUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<UserPhoto> UserPhotoes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}