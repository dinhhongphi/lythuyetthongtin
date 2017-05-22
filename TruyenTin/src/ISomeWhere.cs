using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public interface ISomeWhere
    {
        Task ReceiveAsync(Package package, Duong_Truyen from, ISomeWhere sender);
    }
}
