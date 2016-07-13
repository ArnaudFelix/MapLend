using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MapLend.Business;

namespace MapLend.Mvc.Models
{
    public class ToolViewModel
    {
        public ToolViewModel() { }

        public ToolViewModel(Tool tool) : this(tool, null) { }

        public ToolViewModel(Tool tool, IEnumerable<Category> categories)
        {
            Id = tool.Id;
            Name = tool.Name;
            Status = tool.Status;
            CategoryId = tool.Category.Id;

            Categories = categories;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ToolStatus Status { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}