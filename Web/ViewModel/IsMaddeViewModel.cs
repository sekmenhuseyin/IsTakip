using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ViewModel
{
    public class IsMaddeViewModel
    {
        public IEnumerable<IsMadde> IsMaddeleri { get; set; }
        public Is Is { get; set; }
        public IsMadde IsMadde { get; set; }
    }
}
