using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public class Duong_Truyen 
    {
        public async Task ReceiveAsync(Package package, ISomeWhere sender, ISomeWhere receiver)
        {
#if TEST_DUONG_DI
            Debug.WriteLine("duong_truyen receive from client");
            await ForwardAsync(package, receiver, sender);
#else
            //caculator hamming distance
            int d = package.Data.G.GetMatrix_Check().GetHammingDistance();
            //sinh loi
            var a = SinhLoi(package.Data.W, d);
            var new_package = new Package()
            {
                Code = package.Code,
                Data = new Data()
                {
                    G = package.Data.G,
                    W = a
                }
            };
            //send to receiver
            await ForwardAsync(new_package, receiver, sender);
#endif
        }

        public async Task ForwardAsync(Package package, ISomeWhere receiver, ISomeWhere sender)
        {
#if TEST_DUONG_DI
            Debug.WriteLine("duong_truyen send package to server");
            await ((Server)receiver).ReceiveAsync(package, this, sender);
#else
            await ((Server)receiver).ReceiveAsync(package, this, sender);
#endif
        }

        /// <summary>
        /// make error in w
        /// </summary>
        /// <param name="w"></param>
        /// <param name="d"></param>
        /// <returns></returns>
        private Matrix_Binary SinhLoi(Matrix_Binary w, int d)
        {
            return null;
        }

        /// <summary>
        /// ramdom t in d >= t + 1
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private int Random_t(int d)
        {
            return 1;
        }


    }
}
