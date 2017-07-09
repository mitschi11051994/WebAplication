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
    public class tblReunions1Controller : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblReunions1
        public ActionResult Index()
        {
            return View(db.tblReunion.ToList());
        }

        // GET: tblReunions1/Details/5
        public ActionResult Details(int? id)
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

        // GET: tblReunions1/Create
        public ActionResult Create()
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            return View();
        }

        // POST: tblReunions1/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_reunion,title,fecha_y_hora,id_user,esVirtual,id_client")] tblReunion tblReunion)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            if (ModelState.IsValid)
            {
                db.tblReunion.Add(tblReunion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblReunion);
        }

        // GET: tblReunions1/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
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

        // POST: tblReunions1/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_reunion,title,fecha_y_hora,id_user,esVirtual,id_client")] tblReunion tblReunion)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            if (ModelState.IsValid)
            {
                db.Entry(tblReunion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblReunion);
        }

        // GET: tblReunions1/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: tblReunions1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
