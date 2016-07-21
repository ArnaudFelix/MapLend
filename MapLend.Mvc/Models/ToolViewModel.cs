using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MapLend.Business;

namespace MapLend.Mvc.Models
{
    public class ToolViewModel
    {
        public ToolViewModel() { }

        public ToolViewModel(Tool tool) : this(tool, null, null) { }

        public ToolViewModel(Tool tool, IEnumerable<Category> categories) : this(tool, categories, null) { }

        public ToolViewModel(Tool tool, IEnumerable<Category> categories, User owner)
        {
            if (tool != null)
            {
                Id = tool.Id;
                Name = tool.Name;
                Status = tool.Status;
                if (tool.Category != null)
                {
                    CategoryId = tool.Category.Id;
                }
            }

            if (owner != null)
            {
                UserId = owner.Id;
                UserName = owner.Firstname + " " + owner.Surname;
            }

            Categories = categories;
        }

        public int Id { get; set; }

        [Display(Name = "Nom")]
        public string Name { get; set; }

        [Display(Name = "Statut")]
        public ToolStatus Status { get; set; }

        [Display(Name = "Catégorie")]
        public int CategoryId { get; set; }

        public int UserId { get; set; }
        public string UserName { get; set; }

        public IEnumerable<Category> Categories { get; set; }
    }
}