using MapLend.Business;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLend.DAL
{
    public class MapContext : DbContext
    {
        public MapContext() : base("MapDb")
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Tool> Tools { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Lend> Lends { get; set; }
        public DbSet<LendStatus> LendStatuses { get; set; }
        public DbSet<ToolStatus> ToolStatuses { get; set; }
    }
}