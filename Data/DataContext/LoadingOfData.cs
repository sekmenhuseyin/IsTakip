using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Data.DataContext
{
    public class LoadingOfData : CreateDatabaseIfNotExists<IsTakipContext>
    {
        protected override void Seed(IsTakipContext context)
        {
            List<Rol> Roller = new List<Rol>
            {
                new Rol {RolAdi = "Sistem Yöneticisi" },
                new Rol {RolAdi = "Yönetici" },
                new Rol {RolAdi = "Departman Yöneticisi" },
                new Rol {RolAdi = "Çalışan" }
            };
            Roller.ForEach(rol => context.Rol.Add(rol));
            context.SaveChanges();


            var eleman = new Eleman { Ad= "Yunus Emre", Soyad = "AKBULUT", Url="yunus-emre-akbulut",Eposta = "yunus@istakip.com",Sifre="321", Durum = Enums.PersonelDurumlari.Aktif, IzınGunSayisi = 15, RolId = 1, KayitTarihi = DateTime.Now, Telefon = "05397437835"};
            context.Eleman.Add(eleman);
            context.SaveChanges();
        }
    }
}
