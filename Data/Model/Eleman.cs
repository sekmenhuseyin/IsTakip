using Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Eleman
    {
        //Standart Bilgiler
        [Key]
        public int Id { get; set; }

        [DisplayName("E-posta Adresi")] //Alanı Çektirirken Model den ismini çektireceğimiz zaman bu alanda yazan kısmı çektirebiliriz.  - yns -
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")] //Boş Geçilemez Attribute'u {0} kısmı da anladığım kadarıyal model'in displayname alanını alıyor. - yns -
        [MaxLength(30)] //Alanın veritabanında ki karakter sayısı sınırı. Bunu eklemeyince direk max yapıyor. Bur da performansta ve alanda fark ediyor diyorlar. - yns -
        public string Eposta { get; set; }//Giriş esnasında kullanılacak e-posta adresi

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(25)]
        public string Sifre { get; set; }//Giriş esnasında kullanılacak şifre

        [DisplayName("Ad")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(20)]
        public string Ad { get; set; }//Giriş yapan kullanıcının ad bilgisi

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        [MaxLength(15)]
        public string Soyad { get; set; }//Giriş yapan kullanıcının soyad bilgisi

        [DisplayName("Telefon")]
        [Required(ErrorMessage ="{0} Alanı Boş Geçilemez!")]//knk telefon numarasını da zorunlu yapalım sonuçta basit bi siteye üyelik yapmıyoruz iş yeri burası :D -ozzy- mantıklı kanka :D kalıyoru -yns-
        [MaxLength(20)]
        public string Telefon { get; set; } //Kullanıcının Telefon numarası -ozzy-

        //Giriş yapan kullanıcının avatar görseli bilgileri
        [DisplayName("Kullanıcı Profil Görseli")]
        public byte[] AvatarResim { get; set; }//Bu alan için Required ve Maxlengt attribute'lerini eklemeyeceğiz. Resim boş geçilebilmeli ve karakter sayısını max olması gerekiyor yani default kalması gerekiyor. - yns -
        public string AvatarResimIsmi { get; set; }
        public string AvatarResimTipi { get; set; }

        [DisplayName("Durum")]
        [Required]
        public PersonelDurumlari Durum { get; set; }//Elemana ait durum bilgisi -İzinde,Açığa alındı, İşten Ayrıldı, Aktif Çalışmada-

        [DisplayName("Durum Açıklaması")]
        [MaxLength(255)]
        public string DurumAciklamasi { get; set; }//Gerekli görüldüğü durumlarda eleman durumu ile ilgili açıklama yazılabilir.

        [DisplayName("İş Başlangıç Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        //Kayıt Tarihi Ekleme sırasında otomatik olarak dolacağı için required a gerek yok hemde güncelleme sırasında arıza çıkartabilir. Ayrıca Alan tipi DateTime olduğu için maxlengt e de gerek yok - yns -
        public DateTime KayitTarihi { get; set; }//Elemanın sisteme ilk kayıt tarihi

        [DisplayName("Son Giriş Tarihi")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? SonGiris { get; set; }//Elemanın sitemde son oturum açma tarihi

        [DisplayName("İzin Gün Sayısı")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")]
        public int IzınGunSayisi { get; set; } //Toplam kaç gün izininin olduğunu değer -ozzy-

        [DisplayName("Kullanılan İzin Gün Sayısı")]
        public int? KullanilanToplamIzın { get; set; } //diyelim 3 gün izin aldı bu alan 0 dan 3 e güncellenecek daha sonra 2 gün daha izin aldı 3 den 5 e güncellenecek ekleme olarak gidecek. şimdiye kadar kaç gün izin kullanmış onu görecek -yns-

        [Required]
        [MaxLength(36)] //Url oluşturulurken Ad + Soyad Olarak oluşturulacak o yüzden hatta arada boşluk da olacağı için +1 olacak - yns - -ozzy- Knk elemanın senin gibi iki ismi varsa +2 boşluk olur :D :D
        public string Url { get; set; } //Url Routing yaparken adres çubuğunda düzenleme sayfaları vs sayfalarda id yerine url çıkması daha iyi oluyor. -yns-

        [Required]//DisplayName'e gerek yok ve Required açıklamasına da gerek yok zaten dropdownlist olacak. - yns -
        public int RolId { get; set; }//Roller de Üst seviye yazılım yöneticisi  :D :) (biz), Yönetici, Departman Yöneticisi ve Çalışan olacak
        public virtual Rol Rol { get; set; }

        //Departman yöneticileri ve çalışanların bir departmanlı olacak.
        [DisplayName("Departman Adı")]
        public int? DepartmanId { get; set; }
        public virtual Departman Departman { get; set; }

        public virtual List<Is> Is { get; set; }//Çalışanlar ile iş arasında ki bağ liste şeklinde bir çalışan birden fazla iş alabilir.
        public virtual List<Izin> Izin { get; set; }//Departman yöneticileri ve çalışanların kullandıkları izinler ve izin talepleri tutulacak.
    }
}
