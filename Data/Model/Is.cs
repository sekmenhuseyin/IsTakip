using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Is
    {
        [Key]
        public int Id { get; set; }

        //Knk dediğim gibi bunu ekledim -ozzy- kanka bu alanın eklenmesi bana da mantıklı geldi şimdi açıklama kısmını listede çektirmeyi planlıyodum da uzun bi yazı olursa liste patlar -yns-
        [DisplayName("İş Başlığı")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(75)] //25 çok azdı 75 yaptım -yns- Okey knk -ozzy-
        public string IsBasligi { get; set; }

        [DisplayName("İş Açıklaması")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(255)]
        public string IsAciklamasi{ get; set; }//İş ile ilgili temel açıklama bu alana girilecek

        [DisplayName("Durum")]
        [Required]
        public IsDurumlari Durum { get; set; }//İş durumu hakkında bilgi Tamamlandı, sürdürülmekte, müşteri beklenmekte, iptal vs. gibi seçenekler //Yeni Proje = 1, Devam Ediyor = 2, Tamamlandı = 3, İptal = 4

        [DisplayName("Durum Açıklaması")]
        [MaxLength(255)]
        public string DurumAciklama { get; set; }//Gerekli görülen durumlarda açıkalama eklenebilir.

        //Knk İşin eklenme, güncellenme ve bitiş tarihini otomatik alırız diye düşünüp [Required] Eklemedim bunlara -ozzy-
        [DisplayName("İşin Eklenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? Tarih { get; set; }//İşin eklenme tarihi

        [DisplayName("İşin Güncellenme Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? GuncellemeTarihi { get; set; }//İş ile ilgili güncelleme tarihleri

        [DisplayName("İşin Bitiş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? BitisTarihi { get; set; }//İşin tamamlandığı yada iptal olduğu tarih

        [Required]
        [MaxLength(75)]//knk bu urlyi açıklamadan mı çekeceğiz yada benim eklediğim isimden mi zaten buraya gelince fark ettim isim olayını -ozzy- kanka senin eklediğin iş adı kısmından çektiririz. -yns -
        public string Url { get; set; } //Url Routing yaparken adres çubuğunda düzenleme sayfaları vs sayfalarda id yerine url çıkması daha iyi oluyor. -yns-

        [DisplayName("Departman")]
        [Required]
        public int DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        public virtual List<IsMadde> IsMadde { get; set; }//Bir işin alt manddeleri olabilir.
        public virtual List<Eleman> Eleman { get; set; }//Bir iş ile birden fazla eleman ilgileniyor olabilir.
    }
}
