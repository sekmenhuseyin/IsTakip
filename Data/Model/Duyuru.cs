using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public class Duyuru
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Duyuru Başlığı")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(100)]
        public string  Duyurubasligi{ get; set; }

        [DisplayName("Duyuru İçeriği")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(512)]
        public string Icerik { get; set; }

        [Required]
        public string OnYazi { get; set; }

        /* Required yok Datetime ın yanında ? var Display name var bir der ek olarak eklediğim bu attribute u buldum*/
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DuyuruTarihi { get; set; }
        
        [Required]
        public int EkleyenId { get; set; }

        [Required]
        public string Url { get; set; }

        public DuyuruTipleri DuyuruTipi { get; set; }

        public virtual Eleman Ekleyen { get; set; }



    }
}
