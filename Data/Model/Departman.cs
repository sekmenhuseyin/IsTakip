using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Data.Model
{
    public class Departman
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Departman Adı")]
        [Required(ErrorMessage = "{0} Alanı Boş Geçilemez !")] //kanka yazılımda bütünlük olsun dite senin bırakılamaz ları geçilemez yapıyorum haberib olsun :) -yns- bENİM İÇİN FARK ETMEZ KNK BEN İNTERNETTEN BAKTIM ÇOĞINLUK BIRAKILAMAZ YAPMIŞTI ;) -OZZY-
        [MaxLength(40)]//40 karakter Departman ismi için yeterlimi bilmiyorum knk -ozzy- 40 yeterli kanka  -yns-
        public string DepartmanAdi { get; set; }//Departmana verilen ismin girileceği alan

        [DisplayName("Departman Durumu")]
        [Required]
        public bool Durum { get; set; }//Departmanın durumu -aktif veya pasif şeklinde düzenlenebilir ve diğer bölümlerde ki gibi durum açıklamasına gerek duymadım-

        [Required]
        [MaxLength(40)]//knk departman isminde kaç tane boşluk kullanacağı bilinmediğinde +5 yaptım // kanka boşluklar da karakter sayıldığı için o 40'ın içinde onlar da var o yüzden url de 40 olacak.
        public string Url { get; set; } //Url Routing yaparken adres çubuğunda düzenleme sayfaları vs sayfalarda id yerine url çıkması daha iyi oluyor. -yns-

        //Departman Yöneticisi Tektir ve Bilgileri burada tutulacak.
        [DisplayName("Departman Yöneticisi")]
        public int? YoneticiId { get; set; }
        //public virtual Eleman Yonetici { get; set; } //-yns kanka otomatik doldurma işlemi sırasında hata vermesinin sebebi buymuş aynı model dosayası içinde aynı nesneden 2 tame alıyoruz ya hem bur satırda hemde aşağıdaki listede ondan hata veriyormuş.Bunu kaldırdım bende sadece Id değerini aldırsak yeter. -ozzy- Tamamdır knk yapacak bi şey yok :D

    }
}
