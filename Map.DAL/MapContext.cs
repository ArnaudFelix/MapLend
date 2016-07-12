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


    }
}