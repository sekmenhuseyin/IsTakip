using System.ComponentModel.DataAnnotations;

namespace Data.Enums
{
    public enum IsDurumlari
    {
        [Display(Name = "Yeni İş")]
        Yeni = 1,
        [Display(Name = "Devam Ediyor")]
        Devam = 2,
        [Display(Name = "Tamamlandı")]
        Tamamlandi = 3,
        [Display(Name = "İptal Edildi")]
        Iptal = 4
    }
}
