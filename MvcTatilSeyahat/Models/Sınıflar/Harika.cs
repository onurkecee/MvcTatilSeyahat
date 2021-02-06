using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTatilSeyahat.Models.Sınıflar
{
    public class Harika
    {
        [Key]
        public int ID { get; set; }
        public string KATEGORIAD { get; set; }
        public string BASLIK { get; set; }
        public string ACIKLAMA { get; set; }
        public string IMAGE { get; set; }
    }
}