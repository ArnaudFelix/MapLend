using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MapLend.Mvc.Models
{
    public class MapUserViewModel
    {
        public int Id { get; set; }

        public char Label { get; set; }

        public string FullName { get; set; }

        public int Rating { get; set; }

        public string Address { get; set; }
    }
}