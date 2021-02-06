using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;
using PagedList.Mvc;

namespace MvcTatilSeyahat.Models.Sınıflar
{
    public class BlogYorum
    {
        public IEnumerable<Blog> blog { get; set; }
        public IEnumerable<Yorum> yorum { get; set; }
        public IEnumerable<Blog> sonyazilar { get; set; }
        public IEnumerable<Yorum> sonyorum { get; set; }
    }
}