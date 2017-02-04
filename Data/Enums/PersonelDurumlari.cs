using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum PersonelDurumlari : int
    {
        [Display(Name = "Aktif Olarak Çalışıyor")]
        Aktif = 1,
        [Display(Name = "İzinde")]
        Izinde = 2,
        [Display(Name = "Açığa Alındı")]
        AcigaAlindi = 3,
        [Display(Name = "İşten Ayrıldı")]
        Ayrildi = 4
    }
}
