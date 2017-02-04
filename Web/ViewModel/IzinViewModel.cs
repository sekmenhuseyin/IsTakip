using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class IzinViewModel
    {
        public Izin Izin{ get; set; }
        public IEnumerable<Izin> Izinler{ get; set; }
        public IEnumerable<Izin> CalisanIzinleri { get; set; }
        public IEnumerable<Izin> GecmisIzinler { get; set; }
    }
}
