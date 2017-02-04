using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IIzinRepository<T> : IRepository<T> where T : class
    {
        T BulveGetir(string Url);
        IEnumerable<T> ElemanaGoreGetir(string Url);
        List<T> DepartmanaGoreGetir(string Url);
    }
}
