using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> TumunuGetir();
        bool Ekle(T obj);
        bool Guncelle(T obj);
        bool Sil(T obj);
        int Say();
    }
}
