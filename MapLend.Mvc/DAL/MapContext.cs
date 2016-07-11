using MapLend.Business;
using MapLend.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLend.Mvc.DAL
{
    public class MapContext : ApplicationDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> MapUsers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<LendStatus> LendStatuses { get; set; }
        public DbSet<ToolStatus> ToolStatuses { get; set; }
    }
}