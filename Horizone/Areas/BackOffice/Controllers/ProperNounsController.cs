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

namespace Horizone.Areas.BackOffice.Controllers
{
    [Authorize(Roles = "Collaborator,Admin")]
    public class ProperNounsController : BaseController
    {
        // GET: BackOffice/ProperNouns
        public ActionResult Index()
        {
            return View(db.ProperNouns.OrderBy(x=>x.Name).ToList());
        }
        // GET: BackOffice/ProperNouns
        public ActionResult NameInStory()
        {
            return View(db.ProperNouns.Where(x=>x.InStory==true).OrderBy(x => x.Name).ToList());
        }
        // GET: BackOffice/ProperNouns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/ProperNouns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,DescriptionEn,DescriptionFr,DescriptionZh,InStory")] ProperNoun properNoun)
        {
            if (ModelState.IsValid)
            {
                db.ProperNouns.Add(properNoun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(properNoun);
        }

        // GET: BackOffice/ProperNouns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProperNoun properNoun = db.ProperNouns.Find(id);
            if (properNoun == null)
            {
                return HttpNotFound();
            }
            return View(properNoun);
        }

        // POST: BackOffice/ProperNouns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,DescriptionEn,DescriptionFr,DescriptionZh,InStory")] ProperNoun properNoun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(properNoun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(properNoun);
        }

        // GET: BackOffice/ProperNouns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProperNoun properNoun = db.ProperNouns.Find(id);
            if (properNoun == null)
            {
                return HttpNotFound();
            }
            return View(properNoun);
        }

        // POST: BackOffice/ProperNouns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProperNoun properNoun = db.ProperNouns.Find(id);
            db.ProperNouns.Remove(properNoun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SearchName(string search)
        {
            IEnumerable<ProperNoun> properNouns = db.ProperNouns;

            if (!string.IsNullOrWhiteSpace(search))
            {
                properNouns = properNouns.Where(x => x.Name.Contains(search));
            }
            if (properNouns.Count() == 0)
            {
                Display("Aucun résultat");
            }
            ViewBag.Search = search;

            return View("SearchName", properNouns.OrderBy(x => x.Name).ToList());
        }
    }
}
