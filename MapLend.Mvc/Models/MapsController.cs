using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MapLend.Business;
using MapLend.Mvc.Infrastructure;

namespace MapLend.Mvc.Models
{
    [Authorize]
    public class MapsController : MapControllerBase
    {
        // GET: Maps
        public ActionResult Index()
        {
            MapListViewModel maps = new MapListViewModel();
            maps.MyMaps = DbCtx.Maps.Where(m => m.Users.Any(u => u.Id == CurrentUser.Id));
            //maps.ReachMaps = DbCtx.Maps.Where(m => m.Address.ZipCode == CurrentUser.Address.ZipCode).Except(maps.MyMaps);
            return View(maps);
        }

        // action permettant de s'ajouter à une map existante  (par proximité ou par nom)
        public ActionResult Inscrire()
        {
            MapListViewModel maps = new MapListViewModel();
            maps.MyMaps = DbCtx.Maps.Where(m => m.Users.Any(u => u.Id == CurrentUser.Id));
            maps.ReachMaps = DbCtx.Maps.Where(m => m.Address.ZipCode == CurrentUser.Address.ZipCode).Except(maps.MyMaps);

            return View(maps);
        }

        [HttpPost]
        public ActionResult Inscrire(int id)
        {
            CurrentUser.Maps.Add(DbCtx.Maps.Find(id));
            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        // enlève l'utilisateur de la map et si celle-ci est vide, la supprime
        public ActionResult Desincrire()
        {
            return null;
        }

        /// affiche :
        ///     - le nom de la map
        ///     - son adresse
        ///     - les membres
        ///     - permet d'inviter des voisins
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Map map = DbCtx.Maps.Find(id);
            if (map == null)
            {
                return HttpNotFound();
            }
            return View(map);
        }

        [HttpPost]
        public ActionResult Inviter(int id, string emails)
        {
            //....
            
            return RedirectToAction("Details", new { Id = id });
        }

        // GET: Maps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Maps/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Map map)
        {
            if (ModelState.IsValid)
            {
                DbCtx.Maps.Add(map);
                DbCtx.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(map);
        }

    }
}
