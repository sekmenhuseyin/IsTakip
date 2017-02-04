using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Data.Model
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Rol Açıklaması")]
        public string RolAdi { get; set; }//Otomatik veri doldurma ile Üst seviye yazılım yöneticisi(biz), Yönetici, Departman Yöneticisi, Çalışan şeklinde doldurulacak.
    }
}
