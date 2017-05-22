using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public class Server : ISomeWhere
    {
        public async Task ReceiveAsync(Package package, Duong_Truyen from, ISomeWhere sender)
        {
#if TEST_DUONG_DI
            Debug.WriteLine("server receive from duong_truyen");
            //request client send again
            var client = (Client)sender;
            Package p = new Package()
            {
                Code = CodeType.GUI_LAI,
                Data = null
            };
            await client.ReceiveAsync(p, null, this);
#else
            if(true) //detect error can fix
            {

            }else //error can't fix
            {
                //request client send again
                var client = (Client)sender;
                Package p = new Package()
                {
                    Code = CodeType.GUI_LAI,
                    Data = null
                };

                await client.ReceiveAsync(p, null, this);
            }
#endif
        }
    }
}
