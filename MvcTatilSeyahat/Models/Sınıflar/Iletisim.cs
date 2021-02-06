using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTatilSeyahat.Models.Sınıflar
{
    public class Iletisim
    {
        [Key]
        public int ID { get; set; }
        public string ADSOYAD { get; set; }
        public string MAIL { get; set; }
        public string KONU { get; set; }
        public string MESAJ { get; set; }
    }
}