using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Web.ViewModel
{
    public class IsViewModel
    {
        public Is Is { get; set; }

        public List<Eleman> Calisanlar { get; set; }
        public List<Eleman> SecilenCalisanlar { get; set; }
        public List<int> SeciliCalisanlarinIdleri{ get; set; }

        public string Sonuc { get; set; }
        public IEnumerable<Departman> Departmanlar { get; set; }
        public IEnumerable<IsMadde> IsMaddeler { get; set; }
    }
}