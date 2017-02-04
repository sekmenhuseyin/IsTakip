using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public interface IRolRepository<T> : IRepository<T> where T : class
    {
        //Bu Interface boş kalacak -en azından şuan için burayı kullanmaya ihtiyacımız olmadığını düşünüyorum.-
    }
}
