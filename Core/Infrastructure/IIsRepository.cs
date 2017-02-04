using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IIsRepository<T> : IRepository<T> where T : class
    {
        T BulveGetir(string Url);
        IEnumerable<T> DepartmanaGoreGetir(string Url);
    }
}
