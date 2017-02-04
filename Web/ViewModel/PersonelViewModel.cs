using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.ViewModel
{
    public class PersonelViewModel
    {
        public Eleman Personel { get; set; }
        public string Sonuc { get; set; }
        public IEnumerable<Departman> Departmanlar { get; set; }
        public IEnumerable<Rol> Roller { get; set; }
    }
}
