using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLend.Business
{
    public enum ToolStatus
    {
        [Display(Name = "Disponible")]
        Available = 1,

        [Display(Name = "Indisponible")]
        Unavailable
    }
}
