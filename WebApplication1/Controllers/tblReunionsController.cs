using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class tblReunionsController : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblReunions
        public ActionResult Index()
        {
            var tblReunion = db.tblReunion.Include(t => t.tblClient).Include(t => t.tblLogin).Include(t => t.tblReunion1).Include(t => t.tblReunion2);
            return View(tblReunion.ToList());
        }

        // GET: tblReunions/Details/5
        public ActionResult Details(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReunion tblReunion = db.tblReunion.Find(id);
            if (tblReunion == null)
            {
                return HttpNotFound();
            }
            return View(tblReunion);
        }

        // GET: tblReunions/Create
        public ActionResult Create()
        {
            ViewBag.id_client = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.id_user = new SelectList(db.tblLogin, "id_user", "Username");
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion");
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion");
            return View();
        }

        // POST: tblReunions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reunion,fecha_y_hora,id_user,esVirtual,id_client")] tblReunion tblReunion)
        {
            if (ModelState.IsValid)
            {
                db.tblReunion.Add(tblReunion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_client = new SelectList(db.tblClient, "id_client", "name", tblReunion.id_client);
            ViewBag.id_user = new SelectList(db.tblLogin, "id_user", "Username", tblReunion.id_user);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            return View(tblReunion);
        }

        // GET: tblReunions/Edit/5
        public ActionResult Edit(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReunion tblReunion = db.tblReunion.Find(id);
            if (tblReunion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_client = new SelectList(db.tblClient, "id_client", "name", tblReunion.id_client);
            ViewBag.id_user = new SelectList(db.tblLogin, "id_user", "Username", tblReunion.id_user);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            return View(tblReunion);
        }

        // POST: tblReunions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reunion,fecha_y_hora,id_user,esVirtual,id_client")] tblReunion tblReunion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblReunion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_client = new SelectList(db.tblClient, "id_client", "name", tblReunion.id_client);
            ViewBag.id_user = new SelectList(db.tblLogin, "id_user", "Username", tblReunion.id_user);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            ViewBag.id_reunion = new SelectList(db.tblReunion, "id_reunion", "id_reunion", tblReunion.id_reunion);
            return View(tblReunion);
        }

        // GET: tblReunions/Delete/5
        public ActionResult Delete(short? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblReunion tblReunion = db.tblReunion.Find(id);
            if (tblReunion == null)
            {
                return HttpNotFound();
            }
            return View(tblReunion);
        }

        // POST: tblReunions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(short id)
        {
            tblReunion tblReunion = db.tblReunion.Find(id);
            db.tblReunion.Remove(tblReunion);
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
