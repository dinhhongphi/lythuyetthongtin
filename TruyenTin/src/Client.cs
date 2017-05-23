using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public class Client : ISomeWhere
    {
        public Matrix_Binary u;
        public Matrix_Binary G;
#if TEST_DUONG_DI
        public int x = 0;
#endif
        public async Task ReceiveAsync(Package package, Duong_Truyen from, ISomeWhere sender)
        {
           if(package.Code == CodeType.GUI_LAI)
            {
#if TEST_DUONG_DI
                x++;
                if (x == 1000)
                    return;
                Debug.WriteLine("Client receive from server");
#endif
                Handler();
            }
            else
            {
                //wait for feature
            }
        }

        private async Task SendAsync(Package package, Duong_Truyen path, ISomeWhere receiver)
        {
#if TEST_DUONG_DI
            Debug.WriteLine("Client start send to duong truyen");
#endif
            await path.ReceiveAsync(package, this, receiver);
        }

        /// <summary>
        /// encrypt u => w
        /// </summary>
        /// <returns></returns>
        private Matrix_Binary Encrypt()
        {
            if(u == null || G == null)
            {
                return null;
            }
            else
            {
                try
                {
                    var w = u.Multiply(G);
                    return w;
                }catch(Exception e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// handle encrypt u => w, then send to server
        /// </summary>
        public void Handler()
        {
#if TEST_DUONG_DI
            //send to server by duong_truyen
            var matrix = new Matrix_Binary(1, 3);
            matrix.SetValue(0, 0, 1);
            matrix.SetValue(0, 1, 1);
            matrix.SetValue(0, 2, 1);
            var package = new Package()
            {
                Code = CodeType.DATA,
                Data = new Data()
                {
                    W = matrix
                }
            };
            var a = new Matrix_Binary(1,2);
            a.SetValue(0, 0, 1);
            a.SetValue(0, 1, 0);
            Log.Write_w(a);
            SendAsync(package, new Duong_Truyen(), new Server());
#else
            //encrypt u => w
            var w = Encrypt();

            //send data to duong_truyen
            var package = new Package()
            {
                Code = CodeType.DATA,
                Data = new Data()
                {
                    G = G,
                    W = w
                }
            };
            SendAsync(package, new Duong_Truyen(), new Server());
#endif
        }

    }
}
