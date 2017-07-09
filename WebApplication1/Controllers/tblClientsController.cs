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
    public class tblClientsController : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblClients
        public ActionResult Index()
        {
            return View(db.tblClient.ToList());
        }

        // GET: tblClients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return HttpNotFound();
            }
            return View(tblClient);
        }

        // GET: tblClients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblClients/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,web_page,direccion,tel,puesto")] tblClient tblClient)
        {
            if (ModelState.IsValid)
            {
                db.tblClient.Add(tblClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblClient);
        }

        // GET: tblClients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return HttpNotFound();
            }
            return View(tblClient);
        }

        // POST: tblClients/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_client,name,web_page,direccion,tel,puesto")] tblClient tblClient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblClient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblClient);
        }

        // GET: tblClients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblClient tblClient = db.tblClient.Find(id);
            if (tblClient == null)
            {
                return HttpNotFound();
            }
            return View(tblClient);
        }

        // POST: tblClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblClient tblClient = db.tblClient.Find(id);
            db.tblClient.Remove(tblClient);
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
