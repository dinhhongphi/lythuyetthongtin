using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public class Log
    {
        public static System.Windows.Forms.TextBox control;

        public static void Write_w(Matrix_Binary w)
        {
            if (control != null)
            {
                var result = "Client mã hóa nguồn (u) thành từ mã (w) : ";
                for (int i = 0; i < w.GetM(); i++)
                {
                    for (int j = 0; j < w.GetN(); j++)
                    {
                        result += w.GetValue(i, j).ToString();
                    }
                }
                result += "\r\n";

                control.AppendText(result);
            }
        }

        public static void Write(string message)
        {
            if (control != null)
            {
                var result = message + "\r\n";
                control.AppendText(result);
            }
        }
        
        public static void Write_Error(Matrix_Binary v, Matrix_Binary h, int d)
        {
            if (control != null)
            {
                var result = "Duong truyen tìm ma trận kiểm tra(h) \r\n";
                for (int i = 0; i < h.GetM(); i++)
                {
                    result += "     ";
                    for (int j = 0; j < h.GetM(); j++)
                    {
                        result += h.GetValue(i, j).ToString() + "  ";
                    }
                    result += "\r\n";
                }

                result += "Duong truyen tìm mã hamming(d) \r\n";
                result += "     d = " + d.ToString() + "\r\n";
                result += "Duong truyen sinh lỗi trên từ mã(v): v = ";
                for (int i = 0; i < v.GetM(); i++)
                {
                    for (int j = 0; j < v.GetN(); i++)
                    {
                        result += v.GetValue(i, j).ToString();
                    }
                }
                result += "\r\n";
                control.AppendText(result);
            }
        }
    }
}
