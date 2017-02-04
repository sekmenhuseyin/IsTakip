using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.ViewModel
{
    public class DuyuruViewModel
    {
        public Duyuru Duyuru { get; set; }
        public IEnumerable<SelectListItem> PersonelListe { get; set; }
        public IEnumerable<SelectListItem> CalisanListe { get; set; }
    }
}