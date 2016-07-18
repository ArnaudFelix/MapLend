using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapLend.Business
{
    public enum LendStatus
    {
        [Display(Name = "Demande en cours")]
        OnDemand = 1,

        [Display(Name = "Prêt accepté")]
        Accepted,

        [Display(Name = "Prêt terminé")]
        Closed
    }
}