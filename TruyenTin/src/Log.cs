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

        public static void Write_vector(string title,Matrix_Binary w)
        {
            if (control != null)
            {
                var result = title;
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
        
        public static void Write_Matrix(string title, Matrix_Binary h)
        {
            if (control != null)
            {
                var result = title +  "\r\n";
                for (int i = 0; i < h.GetM(); i++)
                {
                    result += "     ";
                    for (int j = 0; j < h.GetN(); j++)
                    {
                        result += h.GetValue(i, j).ToString() + "  ";
                    }
                    result += "\r\n";
                }
                result += "\r\n";
                control.AppendText(result);
            }
        }
    }
}
