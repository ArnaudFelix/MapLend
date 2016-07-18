using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MapLend.Mvc.Infrastructure;
using MapLend.Mvc.Models;

namespace MapLend.Mvc.Controllers
{
    [Authorize]
    public class LendController : MapControllerBase
    {
        // Liste de mes prêts & de mes emprunts
        public ActionResult Index()
        {
            ICollection<LendViewModel> lends = new List<LendViewModel>();

            DbCtx.Lends
                .Include(l => l.Tool.Category)
                .Include(l => l.Lender)
                .Include(l => l.Borrower)
                .Where(l => l.Lender.Id == CurrentUser.Id || l.Borrower.Id == CurrentUser.Id)
                .ToList()
                .ForEach(l => lends.Add(new LendViewModel(l)));

            return View(lends);
        }
    }
}