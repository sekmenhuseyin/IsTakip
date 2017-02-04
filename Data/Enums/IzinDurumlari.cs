using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum IzinDurumlari
    {
        [Display(Name = "Onaylandı")]
        Onaylandi = 1,
        [Display(Name = "Beklemede")]
        Beklemede = 2,
        [Display(Name = "İptal Edildi")]
        Iptal = 3,
        [Display(Name = "Reddedildi")]
        Reddedildi = 4
    }
}
