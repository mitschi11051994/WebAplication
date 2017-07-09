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
    public class tblSupport_TicketsController : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblSupport_Tickets
        public ActionResult Index()
        {
            return View(db.tblSupport_Tickets.ToList());
        }

        // GET: tblSupport_Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupport_Tickets tblSupport_Tickets = db.tblSupport_Tickets.Find(id);
            if (tblSupport_Tickets == null)
            {
                return HttpNotFound();
            }
            return View(tblSupport_Tickets);
        }

        // GET: tblSupport_Tickets/Create
        public ActionResult Create()
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            return View();
        }

        // POST: tblSupport_Tickets/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "title,detalle,id_user,id_client,estado")] tblSupport_Tickets tblSupport_Tickets)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            if (ModelState.IsValid)
            {
                db.tblSupport_Tickets.Add(tblSupport_Tickets);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblSupport_Tickets);
        }

        // GET: tblSupport_Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupport_Tickets tblSupport_Tickets = db.tblSupport_Tickets.Find(id);
            if (tblSupport_Tickets == null)
            {
                return HttpNotFound();
            }
            return View(tblSupport_Tickets);
        }

        // POST: tblSupport_Tickets/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_Support_Tickets,title,detalle,id_user,id_client,estado")] tblSupport_Tickets tblSupport_Tickets)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            ViewBag.TipoUsuario = new SelectList(db.tblLogin, "id_user", "Username");
            if (ModelState.IsValid)
            {
                db.Entry(tblSupport_Tickets).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblSupport_Tickets);
        }

        // GET: tblSupport_Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblSupport_Tickets tblSupport_Tickets = db.tblSupport_Tickets.Find(id);
            if (tblSupport_Tickets == null)
            {
                return HttpNotFound();
            }
            return View(tblSupport_Tickets);
        }

        // POST: tblSupport_Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblSupport_Tickets tblSupport_Tickets = db.tblSupport_Tickets.Find(id);
            db.tblSupport_Tickets.Remove(tblSupport_Tickets);
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
