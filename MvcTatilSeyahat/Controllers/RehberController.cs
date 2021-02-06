using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcTatilSeyahat.Models.Sınıflar;

namespace MvcTatilSeyahat.Controllers
{
    public class RehberController : Controller
    {
        Context c = new Context();
        // GET: Rehber
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AntikHarika()
        {
            var antik = c.Harikas.Where(x => x.KATEGORIAD == "Antik").ToList();
            return View(antik);
        }

        public ActionResult AntikHarikaDetay(int id)
        {
            var antik = c.Harikas.Where(x => x.ID == id).ToList();
            return View(antik);
        }

        public ActionResult DogalHarika()
        {
            var dogal = c.Harikas.Where(x => x.KATEGORIAD == "Dogal").ToList();
            return View(dogal);
        }

        public ActionResult DogalHarikaDetay(int id)
        {
            var dogal = c.Harikas.Where(x => x.ID == id).ToList();
            return View(dogal);
        }

        public ActionResult YeniHarika()
        {
            var yeni = c.Harikas.Where(x => x.KATEGORIAD == "Yeni").ToList();
            return View(yeni);
        }

        public ActionResult YeniHarikaDetay(int id)
        {
            var yeni = c.Harikas.Where(x => x.ID == id).ToList();
            return View(yeni);
        }

        public ActionResult SuAltıHarika()
        {
            var sualtı = c.Harikas.Where(x => x.KATEGORIAD == "Su").ToList();
            return View(sualtı);
        }

        public ActionResult SuAltıHarikaDetay(int id)
        {
            var su = c.Harikas.Where(x => x.ID == id).ToList();
            return View(su);
        }
    }
}