using MvcCv.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        
        DbCvEntities db = new DbCvEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(TblAdmin admin)
        {
            var value = db.TblAdmin.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);

            if (value != null)
            {
                FormsAuthentication.SetAuthCookie(value.Username, false);
                Session["Username"] = value.Username.ToString();
                return RedirectToAction("Index","About");
            }
            else
            {
                ViewBag.errorMessage = "Kullanıcı adı veya şifre hatalı.";
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}