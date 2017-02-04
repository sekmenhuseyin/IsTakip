using Core.Infrastructure;
using Data.DataContext;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class IzinRepository : IIzinRepository<Izin>
    {

        private readonly IsTakipContext db = new IsTakipContext();

        public Izin BulveGetir(string Url)
        {
            return db.Izin.FirstOrDefault(x => x.Url == Url);
        }

        public List<Izin> DepartmanaGoreGetir(string Url)
        {
            var DepartmanBul = db.Departman.Where(x => x.Url == Url).FirstOrDefault();
            var PersonelListesi = db.Eleman.Where(x => x.RolId == 4 && x.DepartmanId == DepartmanBul.Id).ToList();
            List<Izin> IzinListesi = null;
            foreach (var item in PersonelListesi)
            {
                IzinListesi = db.Izin.Where(x => x.ElemanId == item.Id).ToList();
            }

            return IzinListesi;
        }

        public bool Ekle(Izin obj)
        {
            try
            {
                db.Izin.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Izin> ElemanaGoreGetir(string Url)
        {
            return db.Izin.Where(x => x.Eleman.Url == Url).OrderBy(x => x.IzinDurum);
        }

        public bool Guncelle(Izin obj)
        {
            try
            {
                db.Izin.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Say()
        {
            return db.Izin.Count();
        }

        public bool Sil(Izin obj)
        {
            try
            {
                db.Izin.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Izin> TumunuGetir()
        {
            return db.Izin.ToList().OrderBy(x => x.IzinDurum);
        }
    }
}
