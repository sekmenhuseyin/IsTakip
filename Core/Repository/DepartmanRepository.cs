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
    public class DepartmanRepository : IDepartmanRepository<Departman>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public Departman BulveGetir(string Url)
        {
            return db.Departman.FirstOrDefault(x => x.Url == Url);
        }

        public IEnumerable<Departman> TumunuGetir()
        {
            return db.Departman.ToList();
        }

        public bool Ekle(Departman obj)
        {
            try
            {
                db.Departman.Add(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Guncelle(Departman obj)
        {
            try
            {
                db.Departman.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Sil(Departman obj)
        {
            try
            {
                db.Departman.Remove(obj);
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
            return db.Departman.Count();
        }
    }
}
