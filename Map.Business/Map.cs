using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Map
    {
        public ICollection<User> Users { get; set; }

        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }
    }
}