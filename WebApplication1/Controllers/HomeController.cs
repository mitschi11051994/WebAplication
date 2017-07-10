using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        CMDEntities d = new CMDEntities();
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult IndexUser()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblLogin model,string returnUrl)
        {
            CMDEntities db = new CMDEntities();
            var dataItem = db.tblLogin.Where(x => x.Username == model.Username && x.Password == model.Password).FirstOrDefault();
            if (dataItem != null)
            {
                FormsAuthentication.SetAuthCookie(dataItem.Username, false);
                if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                         && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    tblLogin login = db.tblLogin.FirstOrDefault(
                        x => x.Username == model.Username && x.Password == model.Password);
                    var datos = login.Role;
                    if (datos.Length > 0)
                    {
                        if (datos == "Admin")
                        {
                            return RedirectToAction("Index");
                        }
                        else
                        {
                            if (datos == "User")
                            {
                                return RedirectToAction("IndexUser");
                            }
                        }
                    }
                }
            }
            return View();
        }


        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Home");
        }
    }
}