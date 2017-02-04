using Core.Infrastructure;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.DataContext;
using System.Data.Entity.Migrations;

namespace Core.Repository
{
    public class IsMaddeRepository : IIsMaddeRepository<IsMadde>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public IsMadde BulveGetir(string Url)
        {
            return db.IsMadde.FirstOrDefault(x=>x.Url==Url);
        }

        public bool Ekle(IsMadde obj)
       {
            try
            {
                db.IsMadde.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
       }

        public bool Guncelle(IsMadde obj)
        {
            try
            {
                db.IsMadde.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<IsMadde> IseGoreMaddeListele(string Url)
        {
            return db.IsMadde.Where(x => x.Is.Url == Url).ToList();
        }

        public int Say()
        {
            return db.IsMadde.Count();
        }

        public bool Sil(IsMadde obj)
        {
            try
            {
                db.IsMadde.Remove(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<IsMadde> TumunuGetir()
        {
            return db.IsMadde.ToList();
        }
    }
}
