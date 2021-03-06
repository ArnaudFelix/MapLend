﻿using System;
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

            ViewBag.CurrentUser = CurrentUser;

            return View(lends);
        }

        // Demande un outil en prêt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Ask(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Tool toolToLend = DbCtx.Tools.Include(t => t.User).First(t => t.Id == id);
            Lend lend = new Lend {
                Borrower = CurrentUser,
                Lender = toolToLend.User,
                Tool = toolToLend,
                Status = LendStatus.OnDemand
            };

            toolToLend.Status = ToolStatus.Lended;

            DbCtx.Lends.Add(lend);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        // Annule une demande
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cancel(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lend lendToCancel = DbCtx.Lends.Include(l => l.Tool).First(l => l.Id == id);

            lendToCancel.Tool.Status = ToolStatus.Available;

            DbCtx.Lends.Remove(lendToCancel);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        // Accepte un prêt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Accept(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lend acceptingLend = DbCtx.Lends.Find(id);

            acceptingLend.Status = LendStatus.Accepted;
            acceptingLend.BeginDate = DateTime.Now;

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        // Refuse un prêt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Refuse(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lend refusingLend = DbCtx.Lends.Find(id);

            refusingLend.Tool.Status = ToolStatus.Available;

            DbCtx.Lends.Remove(refusingLend);

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }

        // Clôture un prêt
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Close(int? id, int? notation)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Lend closingLend = DbCtx.Lends.Find(id);

            closingLend.Status = LendStatus.Closed;
            closingLend.EndDate = DateTime.Now;
            closingLend.Rating = notation;

            closingLend.Tool.Status = ToolStatus.Available;

            //User borrower = DbCtx.MapUsers.Include(u => u.BorrowedTools).First(u => u.Id == closingLend.Borrower.Id);
            closingLend.Borrower.EvaluateRatingValue();

            DbCtx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}