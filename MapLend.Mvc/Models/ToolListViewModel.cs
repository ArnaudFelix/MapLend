using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapLend.Business;

namespace MapLend.Mvc.Models
{
    public class ToolListViewModel
    {
        public IEnumerable<ToolViewModel> Tools { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}