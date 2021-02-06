using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTatilSeyahat.Models.Sınıflar;
using PagedList;
using PagedList.Mvc;

namespace MvcTatilSeyahat.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        // GET: Blog
        BlogYorum by = new BlogYorum();
        public ActionResult Index(int sayfa = 1)
        {
            var blog = c.Blogs.ToList().ToPagedList(sayfa, 10);
            //by.sonyazilar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            //var blog = c.Blogs.ToList();
            return View(blog);
        }

        public ActionResult BlogDetay(int id)
        {
            by.blog = c.Blogs.Where(x => x.ID == id).ToList();
            by.yorum = c.Yorums.Where(x => x.BLOGID == id).ToList();
            by.sonyazilar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            by.sonyorum = c.Yorums.OrderByDescending(x => x.ID).Take(3).ToList();
            // var blogdetay = c.Blogs.Where(x => x.ID == id).ToList();
            return View(by);
        }

        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorum p)
        {
            c.Yorums.Add(p);
            c.SaveChanges();
            return PartialView();
        }

        public PartialViewResult SonYorumlar()
        {
            var sonyorum = c.Yorums.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(sonyorum);
        }

        public PartialViewResult SonYazılar()
        {
            var sonyazilar = c.Blogs.OrderByDescending(x => x.ID).Take(3).ToList();
            return PartialView(sonyazilar);
        }
    }
}