using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GendacBluesheet;


namespace GendacBluesheet.Controllers
{
    public class BluesheetController : Controller
    {
        private GendacBlueSheetEntities db = new GendacBlueSheetEntities();

        // GET: Bluesheet
        public ActionResult Home()
        {
            return View(db.bluesheetdocuments.ToList());
        }

        public ActionResult Configure()
        {
            return View();
        }

        // GET: Bluesheet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bluesheetdocument bluesheetdocument = db.bluesheetdocuments.Find(id);
           
            if (bluesheetdocument == null)
            {
                return HttpNotFound();
            }
            return View(bluesheetdocument);
        }

        // GET: Bluesheet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bluesheet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "compName,oppType,oppSize,oppTime,id,location,clientAge,turnOver,respMode,industry,clientComp,techDependancy,advisable,extDev,extDevSpend")] bluesheetdocument bluesheetdocument,
            [Bind(Include = "buyerName,buyerType,id,buyerID,winRes")] ICollection<buyer> buyers,
            [Bind(Include = "redFlag1,strategy,id,redFlagID")] ICollection<redFlag> redFlags,
            [Bind(Include = "strength1,leverage,id,strengthID")] ICollection<strength> strengths)
        {
            if (ModelState.IsValid)
            {
                db.bluesheetdocuments.Add(bluesheetdocument);
                if (buyers != null)
                {
                    foreach(buyer b in buyers)
                    {
                        db.buyers.Add(b);
                    }
                }
                if (redFlags != null)
                {
                    foreach (redFlag r in redFlags)
                    {
                        db.redFlags.Add(r);
                    }
                }
                if (strengths != null)
                {
                    foreach (strength s in strengths)
                    {
                        db.strengths.Add(s);
                    }
                }

              
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bluesheetdocument);
        }

        // GET: Bluesheet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bluesheetdocument bluesheetdocument = db.bluesheetdocuments.Find(id);
            if (bluesheetdocument == null)
            {
                return HttpNotFound();
            }
            return View(bluesheetdocument);
        }

        // POST: Bluesheet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "compName,oppType,oppSize,oppTime,id,location,clientAge,turnOver,respMode,industry,clientComp,techDependancy,advisable,extDev,extDevSpend,otherComp,budgetElse,intResources,doNothing")] bluesheetdocument bluesheetdocument,
            [Bind(Include = "buyerName,buyerType,id,buyerID,winRes")] ICollection<buyer> buyers)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in buyers)
                {
                    db.Entry(item).State = EntityState.Modified;
                }
                
                db.Entry(bluesheetdocument).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bluesheetdocument);
        }


        // GET: Bluesheet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bluesheetdocument bluesheetdocument = db.bluesheetdocuments.Find(id);
            if (bluesheetdocument == null)
            {
                return HttpNotFound();
            }
            return View(bluesheetdocument);
        }

        // POST: Bluesheet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            bluesheetdocument bluesheetdocument = db.bluesheetdocuments.Find(id);
            db.bluesheetdocuments.Remove(bluesheetdocument);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
