using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTatilSeyahat.Models.Sınıflar
{
    public class Blog
    {
        [Key]
        public int ID { get; set; }
        public string BASLIK { get; set; }
        public DateTime TARIH { get; set; }
        public string ACIKLAMA { get; set; }
        public string BLOGIMAGE { get; set; }
        public ICollection<Yorum> YORUMLAR { get; set; }
    }
}