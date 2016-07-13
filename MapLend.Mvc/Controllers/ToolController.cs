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
    public class ToolController : MapControllerBase
    {
        // Liste de mes outils
        public ActionResult Index()
        {
            ToolListViewModel tools = new ToolListViewModel();

            tools.Categories = DbCtx.Categories.OrderBy(c => c.Name);
            var toolList = new List<ToolViewModel>();
            DbCtx.Tools.Include(t => t.Category).Where(t => t.User.Id == CurrentUser.Id).ToList().ForEach(t => toolList.Add(new ToolViewModel(t)));

            tools.Tools = toolList;

            return View(tools);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(ToolViewModel tool)
        {
            return View();
        }

        public ActionResult Edit(int? id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToolViewModel tool)
        {
            return View();
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ToolViewModel tool)
        {
            return View();
        }
    }
}