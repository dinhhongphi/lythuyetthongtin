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
            var G = package.Data.G;
            var v = package.Data.W;
            Log.Write_vector("Server : nhận được từ mã có giá trị ", v);
            var standar_matrix = G.ConvertTo_Standard_Form();
            Log.Write_Matrix("Server : tính được ma trận hệ thống ", standar_matrix);
            var h = standar_matrix.GetMatrix_Check();
            Log.Write_Matrix("Server : tính được ma trận kiểm tra H", h);
            int d = h.GetHammingDistance();
            Log.Write("Server : tính d = " + d.ToString());
            var h_chuyen_vi = h.Get_Matrix_Chuyen_vi();
            var temp = v.Multiply(h_chuyen_vi);
            Log.Write_vector("Server : tính v. H^T = ", temp);
            int flag = 0; //defaul v.h_chuyen_vi = 0, không có lỗi
            for (int i = 0; i < temp.GetM(); i++)
            {
                for (int j = 0; j < temp.GetN(); j++)
                {
                    if (temp.GetValue(i, j) != 0)
                    {
                        flag++;
                    }
                }
                //if (flag == 0)
                //    break;
            }
            if (flag != 0) //have error
            {
                //t + 1 <= d
                int t = (d - 1) / 2;
                
                if (flag <= t) //detect error can fix
                {
                    Log.Write("Server : Xuất hiện lỗi. Có thể fix được");
                }
                else //error can't fix
                {
                    //request client send again
                    var client = (Client)sender;
                    Package p = new Package()
                    {
                        Code = CodeType.GUI_LAI,
                        Data = null
                    };
                    Log.Write("Server : Xuất hiện lỗi, không thể fix được. Yêu cầu client gửi lại");
                    await client.ReceiveAsync(p, null, this);
                }
            }
            else
            {
                //don't have error
                Log.Write("Server : Không xuất hiện lỗi");
            }
#endif
        }
    }
}
