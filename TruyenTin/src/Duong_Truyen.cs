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
            var h = package.Data.G.GetMatrix_Check();
            Log.Write_Matrix("Đường truyền tính được ma trận kiểm tra H", h);
            int d = h.GetHammingDistance();
            Log.Write("Đường truyền tính d = " + d.ToString());
            //sinh loi
            var a = SinhLoi(package.Data.W, d);
            Log.Write_vector("Sau khi random nhiễu w có giá trị: ", a);
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
            Log.Write("Đường truyền gửi gói tin tới server");
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
            int t = Random_t(d);
            bool[] flag = new bool[w.GetN()];
            for(int i = 0; i < w.GetN(); i++)
            {
                flag[i] = false;
            }
            Random r = new Random();
            for(int i = 0; i < t; i++)
            {
                int bit;
                do
                {
                    bit = r.Next(w.GetN());
                } while (!flag[bit]);
                w.SetValue(0, bit, w.GetValue(0, bit) ^ 1); //đảo bit
            }
            return w;
        }

        /// <summary>
        /// ramdom t in d >= t + 1
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        private int Random_t(int d)
        {
            Random r = new Random();
            int t = r.Next(d);
            return t;
        }


    }
}
