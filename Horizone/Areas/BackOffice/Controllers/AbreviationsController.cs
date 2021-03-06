﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Horizone.Controllers;
using Horizone.Models;
using PagedList;

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class AbreviationsController : BaseController
    {

        // GET: BackOffice/Abreviations
        public ActionResult Index(int page = 1, int pageSize = 20)
        {
            return View(db.Abreviations.OrderBy(x => x.Symbol).ToPagedList(page, pageSize));
        }
        // GET: BackOffice/Verbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abbreviation = db.Abreviations.SingleOrDefault(y => y.Id == id);

            if (abbreviation == null)
            {
                return HttpNotFound();
            }
            return View(abbreviation);
        }
        // GET: BackOffice/Abreviations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Abreviations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Symbol,Description,Link")] Abreviation abreviation)
        {
            if (ModelState.IsValid)
            {
                db.Abreviations.Add(abreviation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(abreviation);
        }

        // GET: BackOffice/Abreviations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.Find(id);
            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }

        // POST: BackOffice/Abreviations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Symbol,Description,Link")] Abreviation abreviation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(abreviation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(abreviation);
        }

        // GET: BackOffice/Abreviations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Abreviation abreviation = db.Abreviations.Find(id);
            if (abreviation == null)
            {
                return HttpNotFound();
            }
            return View(abreviation);
        }

        // POST: BackOffice/Abreviations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Abreviation abreviation = db.Abreviations.Find(id);
            db.Abreviations.Remove(abreviation);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
