using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using MapLend.Mvc.Infrastructure;
using MapLend.Mvc.Models;
using MapLend.Business;
using System.Net;

namespace MapLend.Mvc.Controllers
{
    [Authorize]
    public class ToolController : MapControllerBase
    {
        // Liste de mes outils
        public ActionResult Index()
        {
            ToolListViewModel tools = new ToolListViewModel();

            // Catégories non vides :
            IQueryable<int> catIds = DbCtx.Tools.Where(t => t.User.Id == CurrentUser.Id).Select(t => t.CategoryId);

            tools.Categories = DbCtx.Categories.Where(c => catIds.Any(cid => cid == c.Id)).OrderBy(c => c.Name);

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

            // Filtre sur le user id pour éviter l'édition des outils du voisin :
            Tool toolToUpdate = DbCtx.Tools.Include(t => t.Category).Single(t => t.Id == id && t.User.Id == CurrentUser.Id);

            if (toolToUpdate.Status == ToolStatus.Lended)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Outil non editable car prêté !");
            }
            else
            {
                ToolViewModel tool = new ToolViewModel(toolToUpdate, DbCtx.Categories.OrderBy(c => c.Name).ToList());
                return View(tool);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ToolViewModel tool)
        {
            Tool updatingTool = DbCtx.Tools.Find(tool.Id);

            updatingTool.Name = tool.Name;
            updatingTool.CategoryId = tool.CategoryId;
            updatingTool.Status = tool.Status;

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tool toolToDelete = DbCtx.Tools.Single(t => t.Id == id);

            DbCtx.Tools.Remove(toolToDelete);
            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            Tool newTool = new Tool();
            newTool.Status = ToolStatus.Available;
            newTool.User = CurrentUser;

            ToolViewModel tool = new ToolViewModel(newTool, DbCtx.Categories.OrderBy(c => c.Name).ToList());
            return View(tool);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ToolViewModel tool)
        {
            Tool addingTool = new Tool();

            addingTool.Name = tool.Name;
            addingTool.CategoryId = tool.CategoryId;
            addingTool.Status = tool.Status;

            addingTool.User = CurrentUser;

            DbCtx.Tools.Add(addingTool);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}