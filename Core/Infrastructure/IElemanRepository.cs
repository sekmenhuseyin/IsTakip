using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{

    public interface IElemanRepository<T> : IRepository<T> where T : class
    {
        T BulveGetir(string Url);
        T IdyeGoreBulveGetir(int Id);
        T Giris(string Eposta, string Sifre);
        IEnumerable<T> DepartmanaGoreGetir(string Url);
        IEnumerable<T> RolIdyeGoreGetir(int RolId);
    }
}
