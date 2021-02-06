using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTatilSeyahat.Models.Sınıflar;

namespace MvcTatilSeyahat.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(6).ToList();
            return View(degerler);
        }

        public PartialViewResult AnasayfaBlog()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult AnasayfaTopOnBlog()
        {
            var degerler = c.Blogs.OrderByDescending(x => x.ID).Take(10).ToList();
            return PartialView(degerler);
        }

        public PartialViewResult AnasayfaAltBlog()
        {
            var blog = c.Blogs.ToList();
            return PartialView(blog);
        }
    }
}