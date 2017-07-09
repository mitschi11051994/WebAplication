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
    public class tblContactController : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblContact
        public ActionResult Index()
        {
            return View(db.tblContact.ToList());
        }

        // GET: tblContact/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = db.tblContact.Find(id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // GET: tblContact/Create
        public ActionResult Create()
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            return View();
        }

        // POST: tblContact/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_client,name,first_name,web_address,tel,puesto")] tblContact tblContact)
        {
            if (ModelState.IsValid)
            {
                db.tblContact.Add(tblContact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            


            return View(tblContact);
        }

        // GET: tblContact/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = db.tblContact.Find(id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // POST: tblContact/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_contact,id_client,name,first_name,web_address,tel,puesto")] tblContact tblContact)
        {
            ViewBag.TipoCliente = new SelectList(db.tblClient, "id_client", "name");
            if (ModelState.IsValid)
            {
                db.Entry(tblContact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblContact);
        }

        // GET: tblContact/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblContact tblContact = db.tblContact.Find(id);
            if (tblContact == null)
            {
                return HttpNotFound();
            }
            return View(tblContact);
        }

        // POST: tblContact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblContact tblContact = db.tblContact.Find(id);
            db.tblContact.Remove(tblContact);
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
