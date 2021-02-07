using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTatilSeyahat.Models.Sınıflar;
using System.Web.Security;

namespace MvcTatilSeyahat.Controllers
{
    public class LoginController : Controller
    {
        Context c = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Admin p)
        {
            var bilgi = c.Admins.FirstOrDefault(x => x.KULLANICI == p.KULLANICI && x.SIFRE == p.SIFRE);
            if (bilgi != null)
            {
                FormsAuthentication.SetAuthCookie(bilgi.KULLANICI, false);
                Session["KULLANICI"] = bilgi.KULLANICI.ToString();
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        public ActionResult UyeLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UyeLogin(Uye p)
        {
            var uye = c.Uyes.FirstOrDefault(x => x.KULLANICIADI == p.KULLANICIADI && x.SIFRE == p.SIFRE);
            if (uye != null)
            {
                FormsAuthentication.SetAuthCookie(uye.KULLANICIADI, false);
                Session["KULLANICIADI"] = uye.KULLANICIADI.ToString();
                return RedirectToAction("Index", "Default");
            }
            else
            {
                return View();
            }
        }
    }
}