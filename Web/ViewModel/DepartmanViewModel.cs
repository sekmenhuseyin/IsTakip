using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.ViewModel
{
    public class DepartmanViewModel
    {
        public Departman Departman { get; set; }
        public string Sonuc { get; set; }
        public IEnumerable<SelectListItem> PersonelListe { get; set; }
    }
}
