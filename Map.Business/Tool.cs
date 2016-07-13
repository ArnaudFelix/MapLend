using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace MapLend.Business
{
    public class Tool
    {
        public Category Category { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public User User { get; set; }

        public string Name { get; set; }

        public int Id { get; set; }

        public ToolStatus Status { get; set; }
    }
}