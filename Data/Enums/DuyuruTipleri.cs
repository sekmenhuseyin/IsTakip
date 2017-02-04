using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Enums
{
    public enum DuyuruTipleri
    {
        [Display(Name = "Genel Duyuru")]
        GelenDuyuru = 1,
        [Display(Name = "Kişiye Özel Duyuru")]
        KisiyeOzelDuyuru = 2
    }
}
