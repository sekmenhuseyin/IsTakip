using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class IsMadde
    {
        [Key]
        public int Id{ get; set; }

        [DisplayName("İş Madde Başlığı")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(50)]
        public string IsMaddeBasligi { get; set; } //Kanka Madde için de hem listede kullanmak üzere hemde url için bi başlık alanı ekleyelim -yns-

        [DisplayName("İş Madde Açıklaması")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(255)]
        public string IsMaddeAciklamasi { get; set; }//İşe Ait Madde

        [DisplayName("Durum")]
        [Required]
        public bool Durum { get; set; }//Maddenin durumu -İş durumunda ki seçenekler aynen bu alan için de geçerli olabilir

        [DisplayName("Durum Açıklaması")]
        [MaxLength(255)]
        public string DurumAciklama { get; set; }//Maddenin durumu ile ilgili açıklama

        [DisplayName("İş Madde Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //[Required] DateTime tiplerde Required a gerek yok kanka  -yns-
        public DateTime? IsMaddeTarih { get; set; }//İş Maddesinin eklenme tarihi

        [DisplayName("İş Madde Güncellenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //[Required] up -yns-
        public DateTime? IsMaddeGuncellemeTarih { get; set; }//İş maddesi ile ilgili güncelleme tarihi

        [DisplayName("İş Madde Bitiş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //[Required] up -yns-
        public DateTime? IsMaddeBitisTarih { get; set; }//İş maddesinin tamamlandığı yada iptal olduğu tarih

        [Required]
        [MaxLength(50)] //Knk bunu Madde'den çektireceksek 255 uzun olur diye düşündüm -ozzy- Başlık alanı, up -yns-
        public string Url { get; set; } //Url Routing yaparken adres çubuğunda düzenleme sayfaları vs sayfalarda id yerine url çıkması daha iyi oluyor. -yns-

        //Maddenin hangi işe ait olduğu belirtilir.
        [Required]
        public int IsId { get; set; }
        public virtual Is Is { get; set; }
    }
}
