using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MapLend.Mvc.Infrastructure;
using MapLend.Mvc.Models;
using MapLend.Business;

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
            DbCtx.Tools
                .Include(t => t.Category)
                .Where(t => t.User.Id == CurrentUser.Id)
                .ToList()
                .ForEach(t => toolList.Add(new ToolViewModel(t)));

            tools.Tools = toolList;

            return View(tools);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangeStatus(ToolViewModel tool, FormCollection fc)
        {
            Tool updatingTool = DbCtx.Tools.Find(tool.Id);
            updatingTool.Status = tool.Status;

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }

            ToolViewModel tool = new ToolViewModel(DbCtx.Tools.Find(id), DbCtx.Categories.OrderBy(c => c.Name).ToList());

            return View(tool);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToolViewModel tool)
        {
            Tool updatingTool = DbCtx.Tools.Find(tool.Id);

            updatingTool.Name = tool.Name;
            updatingTool.CategoryId = tool.CategoryId;

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ToolViewModel tool)
        {
            return View();
        }
    }
}