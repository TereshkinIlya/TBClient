using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrucrure.Interfaces
{
    internal interface IPacker<TRezult, TData>
    {
        TRezult Pack (IEnumerable<TData> data);
    }
}
