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
    public class RolRepository : IRolRepository<Rol>
    {
        private readonly IsTakipContext db = new IsTakipContext();

        public IEnumerable<Rol> TumunuGetir()
        {
            return db.Rol.ToList();
        }

        public bool Ekle(Rol obj)
        {
            try
            {
                db.Rol.Add(obj);
                db.SaveChanges();
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Guncelle(Rol obj)
        {
            try
            {
                db.Rol.AddOrUpdate(obj);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool Sil(Rol obj)
        {
            try
            {
                db.Rol.Remove(obj);
                db.SaveChanges(); //unutmuşsun kanka -yns-
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public int Say()
        {
            return db.Rol.Count();
        }
    }
}
