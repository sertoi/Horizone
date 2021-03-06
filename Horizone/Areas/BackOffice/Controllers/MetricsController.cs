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
    public class MetricsController : BaseController
    {
        
        // GET: BackOffice/Metrics
        public ActionResult Index()
        {
            return View(db.Metrics.ToList());
        }

        
        // GET: BackOffice/Metrics/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BackOffice/Metrics/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,MetricEn,MetricFr,MetricZh")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Metrics.Add(metric);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(metric);
        }

        // GET: BackOffice/Metrics/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: BackOffice/Metrics/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MetricEn,MetricFr,MetricZh")] Metric metric)
        {
            if (ModelState.IsValid)
            {
                db.Entry(metric).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(metric);
        }

        // GET: BackOffice/Metrics/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Metric metric = db.Metrics.Find(id);
            if (metric == null)
            {
                return HttpNotFound();
            }
            return View(metric);
        }

        // POST: BackOffice/Metrics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Metric metric = db.Metrics.Find(id);
            db.Metrics.Remove(metric);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
