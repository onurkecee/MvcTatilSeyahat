using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTatilSeyahat.Models.Sınıflar;

namespace MvcTatilSeyahat.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        Context c = new Context();
        // GET: Admin
        public ActionResult Index()
        {
            var blog = c.Blogs.ToList();
            return View(blog);
        }

        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BLOGIMAGE = "/images/" + dosyaadi + uzanti;
            }
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogSil(int id)
        {
            var blogsil = c.Blogs.Find(id);
            c.Blogs.Remove(blogsil);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BlogGetir(int id)
        {
            var bloggetir = c.Blogs.Find(id);
            //ViewBag.resimad = bloggetir.BLOGIMAGE;
            //bloggetir.TARIH.ToShortDateString();
            return View("BlogGetir", bloggetir);
        }

        public ActionResult BlogGuncelle(Blog p)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/images/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                p.BLOGIMAGE = "/images/" + dosyaadi + uzanti;
            }
            var blogguncelle = c.Blogs.Find(p.ID);
            blogguncelle.BASLIK = p.BASLIK;
            blogguncelle.ACIKLAMA = p.ACIKLAMA;
            blogguncelle.BLOGIMAGE = p.BLOGIMAGE;
            blogguncelle.TARIH = blogguncelle.TARIH;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YorumListesi()
        {
            var yorum = c.Yorums.ToList();
            return View(yorum);
        }

        public ActionResult YorumSil(int id)
        {
            var yorumsil = c.Yorums.Find(id);
            c.Yorums.Remove(yorumsil);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }

        public ActionResult YorumGetir(int id)
        {
            var yorumgetir = c.Yorums.Find(id);
            List<SelectListItem> yorumonay = new List<SelectListItem>();
            foreach (var item in c.Yorums.ToList())
            {
                yorumonay.Add(new SelectListItem { Text = item.YORUMONAY.ToString(), Value = item.ID.ToString() });
            }
            ViewBag.yorumonay = yorumonay;
            return View("YorumGetir", yorumgetir);
        }

        public ActionResult YorumDetay(Yorum p)
        {
            var yorumguncelle = c.Yorums.Find(p.ID);
            yorumguncelle.KULLANICIADI = p.KULLANICIADI;
            yorumguncelle.MAIL = p.MAIL;
            yorumguncelle.YORUM = p.YORUM;
            yorumguncelle.YORUMONAY = p.YORUMONAY;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
    }
}