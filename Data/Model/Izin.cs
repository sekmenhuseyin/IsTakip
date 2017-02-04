using Data.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Izin
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("İzin Başlığı")] //Hem Listede Hem Url için bir başlık -yns-
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(50)]
        public string IzinBasligi { get; set; }

        [DisplayName("İzin Açıklaması")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(255)]
        public string IzinAciklamasi { get; set; }//İzin talebi sırasında izin açıklaması eklenecek.

        [DisplayName("İzin Durumu")]
        [Required]
        public IzinDurumlari IzinDurum { get; set; }//Burada yine birden fazla seçenek olabilir. Beklemede, Onaylandı, Onaylanmadı şeklinde

        [DisplayName("İzin Durumu Açıklaması")]
        [MaxLength(255)]
        public string IzinDurumAciklamasi { get; set; }//İzin onaylandı ise veya onaylanmadı ise nedenleri için bir açıklama alanı

        [Required]
        public int ElemanId { get; set; }//İzin talebinde bulunan Dep. Yönt. veya çalışan bilgisi
        public virtual Eleman Eleman { get; set; }//İzin talebinde bulunan Dep. Yönt. veya çalışan bilgisi

        [DisplayName("İzin Başlangıç Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        public DateTime BaslangicTarihi { get; set; }//İzin Başlangıç Tarihi

        [DisplayName("İzin Bitiş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        public DateTime BitisTarihi { get; set; }//İzin Bitiş Tarihi

        [Required]
        [MaxLength(50)]
        public string Url { get; set; } //Izın Detay'a giderken kullanılacak URL -yns-

    }
}
