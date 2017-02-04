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
    public class IsRepository : IIsRepository<Is>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public Is BulveGetir(string Url)
        {
            return db.Is.FirstOrDefault(x => x.Url == Url);
        }

        public IEnumerable<Is> TumunuGetir()
        {
            return db.Is.ToList();
        }

        public bool Ekle(Is obj)
        {
            try
            {
                db.Is.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Guncelle(Is obj)
        {
            try
            {
                db.Is.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Sil(Is obj)
        {
            try
            {
                db.Is.Remove(obj);
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
            return db.Is.Count();
        }

        public IEnumerable<Is> DepartmanaGoreGetir(string Url)
        {
            var DepartmanBul = db.Departman.FirstOrDefault(x => x.Url == Url);
            return db.Is.Where(x => x.DepartmanId == DepartmanBul.Id);
        }
    }
}
