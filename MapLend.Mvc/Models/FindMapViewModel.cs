using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapLend.Mvc.Models
{
    public class FindMapViewModel
    {
        public int? Id { get; set; }

        public IEnumerable<MapViewModel> ProximityMaps { get; set; }

        public IEnumerable<MapViewModel> NamedMaps { get; set; }
    }
}