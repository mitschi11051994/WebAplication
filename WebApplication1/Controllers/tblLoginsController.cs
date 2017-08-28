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
    public class tblLoginsController : Controller
    {
        private CMDEntities db = new CMDEntities();

        // GET: tblLogins
        public ActionResult Index()
        {
            return View(db.tblLogin.ToList());
        }

        // GET: tblLogins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // GET: tblLogins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblLogins/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Username,Md5(Password),Role")] tblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {

                db.tblLogin.Add(tblLogin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblLogin);
        }

        // GET: tblLogins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: tblLogins/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_user,Username,Md5(Password),Role")] tblLogin tblLogin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblLogin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblLogin);
        }

        // GET: tblLogins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblLogin tblLogin = db.tblLogin.Find(id);
            if (tblLogin == null)
            {
                return HttpNotFound();
            }
            return View(tblLogin);
        }

        // POST: tblLogins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblLogin tblLogin = db.tblLogin.Find(id);
            db.tblLogin.Remove(tblLogin);
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
