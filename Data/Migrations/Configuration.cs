namespace Data.Migrations
{
    using DataContext;
    using Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IsTakipContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(IsTakipContext context)
        {
            List<Rol> Roller = new List<Rol>
            {
                new Rol {RolAdi = "Sistem Y�neticisi" },
                new Rol {RolAdi = "Y�netici" },
                new Rol {RolAdi = "Departman Y�neticisi" },
                new Rol {RolAdi = "�al��an" }
            };
            Roller.ForEach(rol => context.Rol.Add(rol));
            context.SaveChanges();


            var eleman = new Eleman { Ad = "Yunus Emre", Soyad = "AKBULUT", Url = "yunus-emre-akbulut", Eposta = "yunus@istakip.com", Sifre = "321", Durum = Enums.PersonelDurumlari.Aktif, Iz�nGunSayisi = 15, RolId = 1, KayitTarihi = DateTime.Now, Telefon = "05397437835" };
            context.Eleman.Add(eleman);
            context.SaveChanges();
        }
    }
}
