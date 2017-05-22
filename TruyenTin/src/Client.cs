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
                if (x == 100)
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
            return null;
        }

        /// <summary>
        /// handle encrypt u => w, then send to server
        /// </summary>
        public void Handler()
        {
            //encrypt u => w
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

            SendAsync(package, new Duong_Truyen(), new Server());
#else
            //send data to duong_truyen
            var package = new Package()
            {
                Code = CodeType.DATA,
                Data = null
            };

            SendAsync(package, new Duong_Truyen(), new Server());
#endif
        }

    }
}
