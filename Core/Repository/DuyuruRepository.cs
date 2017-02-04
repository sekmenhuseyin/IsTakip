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
    class DuyuruRepository : IDuyuruRepository<Duyuru>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public Duyuru BulveGetir(string Url)
        {
            return db.Duyuru.FirstOrDefault(x => x.Url == Url);
        }

        public IEnumerable<Duyuru> TumunuGetir()
        {
            return db.Duyuru.ToList();
        }

        public bool Ekle(Duyuru obj)
        {
            try
            {
                db.Duyuru.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Guncelle(Duyuru obj)
        {
            try
            {
                db.Duyuru.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sil(Duyuru obj)
        {
            try
            {
                db.Duyuru.Remove(obj);
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
            return db.Duyuru.Count();
        }


        public IEnumerable<Duyuru> ElemanaGoreGetir(string Url)
        {
            throw new NotImplementedException();
        }
    }
}
