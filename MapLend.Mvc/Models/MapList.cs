using MapLend.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapLend.Mvc.Models
{
    public class MapList
    {
        public IEnumerable<Map> MyMaps { get; set; }
        public IEnumerable<Map> ReachMaps { get; set; }
    }
}