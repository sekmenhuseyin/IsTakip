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
    public class ElemanRepository : IElemanRepository<Eleman>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public Eleman BulveGetir(string Url)
        {
            return db.Eleman.FirstOrDefault(x => x.Url == Url);
        }

        public IEnumerable<Eleman> DepartmanaGoreGetir(string Url)
        {
            var DepartmanBul = db.Departman.FirstOrDefault(x => x.Url == Url);
            return db.Eleman.Where(x => x.DepartmanId == DepartmanBul.Id);
        }

        public IEnumerable<Eleman> RolIdyeGoreGetir(int RolId)
        {
            return db.Eleman.Where(x => x.RolId == RolId);
        }

        public bool Ekle(Eleman obj)
        {
            try
            {
                db.Eleman.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Eleman Giris(string Eposta, string Sifre)
        {
            var GirisYapan = db.Eleman.FirstOrDefault(x => x.Eposta == Eposta && x.Sifre == Sifre);
            if (GirisYapan != null)
            {
                return GirisYapan;
            }
            else
            {
                return null;
            }
        }

        public bool Guncelle(Eleman obj)
        {
            try
            {
                db.Eleman.AddOrUpdate(obj);
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
            return db.Eleman.Count();
        }

        public bool Sil(Eleman obj)
        {
            try
            {
                db.Eleman.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Eleman> TumunuGetir()
        {
            return db.Eleman.ToList();
        }

        public Eleman IdyeGoreBulveGetir(int Id)
        {
            return db.Eleman.FirstOrDefault(x => x.Id == Id);
        }
    }
}
