﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcTatilSeyahat.Models.Sınıflar
{
    public class Admin
    {
        [Key]
        public int ID { get; set; }
        public string KULLANICI { get; set; }
        public string SIFRE { get; set; }
    }
}