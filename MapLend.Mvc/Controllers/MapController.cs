using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MapLend.Business;
using MapLend.Mvc.Models;
using MapLend.Mvc.Infrastructure;

namespace MapLend.Mvc.Controllers
{
    [Authorize]
    public class MapController : MapControllerBase
    {
        // GET: Maps
        public ActionResult Index()
        {
            return View(MapViewModel.CastIntoList(CurrentUser.Maps.ToList()));
        }

        public ActionResult Details(int id)
        {
            Map map = DbCtx.Maps.Find(id);

            return View(new MapViewModel(map, withUsers: true));
        }

        public ActionResult Find(string name)
        {
            FindMapViewModel findMaps = new FindMapViewModel();

            findMaps.ProximityMaps = MapViewModel.CastIntoList(
                DbCtx.Maps
                    .Where(m => m.Address.ZipCode == CurrentUser.Address.ZipCode)
                    .Except(DbCtx.MapUsers.Where(u => u.Id == CurrentUser.Id).SelectMany(u => u.Maps))
                    .ToList()
                );
            
            if (!string.IsNullOrWhiteSpace(name))
            {
                findMaps.NamedMaps = MapViewModel.CastIntoList(
                DbCtx.Maps
                    .Where(m => m.Name.Contains(name))
                    .Except(DbCtx.MapUsers.Where(u => u.Id == CurrentUser.Id).SelectMany(u => u.Maps))
                    .ToList()
                );
            }

            return View(findMaps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Subscribe(int? id)
        {
            Map newSubscription = DbCtx.Maps.Find(id);

            CurrentUser.Maps.Add(newSubscription);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Unsubscribe(int? id)
        {
            Map mapToUnsubscribe = DbCtx.Maps.Find(id);

            CurrentUser.Maps.Remove(mapToUnsubscribe);

            if (mapToUnsubscribe.Users.Count == 0)
            {
                DbCtx.Maps.Remove(mapToUnsubscribe);
            }

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string newMapName)
        {
            Map newMap = new Map
            {
                Name = newMapName,
                Address = (Address)CurrentUser.Address.Clone(),
                Users = new List<User> { CurrentUser }
            };

            DbCtx.Maps.Add(newMap);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}