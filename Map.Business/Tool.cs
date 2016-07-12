using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Tool
    {
        public Category Category { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public ToolStatus ToolStatus { get; set; }
    }
}