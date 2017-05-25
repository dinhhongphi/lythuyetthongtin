using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruyenTin.src
{
    public class Matrix_Binary
    {
#if TEST
        public int m;
        public int n;
        public int[,] matrix;
#else
        private int m;
        private int n;
        private int[,] matrix;
#endif
        public Matrix_Binary(int m, int n)
        {
            this.m = m;
            this.n = n;
            matrix = new int[m, n];
        }

        /// <summary>
        /// Set value for matrix at [i,j]
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <param name="value"></param>
        public void SetValue(int i, int j, int value)
        {
            if (value == 0 || value == 1)
            {
                matrix[i, j] = value;
            }
            else
            {
                throw new ArgumentException("value must in [0,1]");
            }
        }

        /// <summary>
        /// Get value of matrix at [i,j]
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int GetValue(int i, int j)
        {
            return matrix[i, j];
        }

        /// <summary>
        /// Multiply two matrix
        /// </summary>
        /// <param name="second"></param>
        /// <returns></returns>
        public Matrix_Binary Multiply(Matrix_Binary second)
        {
            if (this.n == second.GetM()) //thỏa điều kiện nhân hai ma trận
            {
                Matrix_Binary c = new Matrix_Binary(this.m, second.GetN());

                for (int i = 0; i < c.GetM(); i++)
                {
                    for (int j = 0; j < c.GetN(); j++)
                    {
                        int result = 0;
                        for (int k = 0; k < this.n; k++)
                        {
                            result ^= this.matrix[i, k] * second.GetValue(k, j);
                        }
                        c.SetValue(i, j, result);
                    }
                }
                return c;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get matrix kiểm tra
        /// </summary>
        /// <returns></returns>
        public Matrix_Binary GetMatrix_Check()
        {
            int i, j, temp = m;
            Matrix_Binary Ma_tran_H = new Matrix_Binary((n - m),n);
            for (i = 0; i < m; i++)
            {
                for (j = m; j < n; j++)
                {

                    Ma_tran_H.SetValue(j - m, i, matrix[i, j]);
                }
            }
            for (i = 0; i < n - m; i++)
            {
                for (j = m; j < n; j++)
                {
                    if (j == temp) Ma_tran_H.SetValue(i, j, 1);
                    else Ma_tran_H.SetValue(i, j, 0);
                }
                temp++;
            }
            return Ma_tran_H;
        }

        public Matrix_Binary Get_Matrix_Chuyen_vi()
        {
            Matrix_Binary result = new Matrix_Binary(this.n, this.m);
            for (int i = 0; i < result.GetM(); i++)
            {
                for (int j = 0; j < result.GetN(); j++)
                {

                    result.SetValue(i,j,matrix[j,i]);
                }
            }
            return result;
        }

        /// <summary>
        /// Caculator hamming distance
        /// </summary>
        /// <returns></returns>
        public int GetHammingDistance()
        {
            int d = 1;
            while (d < this.n)
            {
                Matrix_Binary column = new Matrix_Binary(this.m, 1);
                for (int j = 0; j < this.m; j++)
                {
                    column.SetValue(j, 0, matrix[j, 0]);//copy column j
                }
                var result = Sum_next(column, d - 1,1);
                if(result == d - 1)
                {
                    return d;
                }
                ++d;
            }
            return -1;
        }

        public int Sum_next(Matrix_Binary sum_before, int d_temp, int column_current)
        {
            if (column_current > d_temp)
            {
                int flag = 1; //giả sử tổng bằng 0
                for (int i = 0; i < sum_before.GetM(); i++)
                {
                    if (sum_before.GetValue(i, 0) != 0)
                    {
                        flag = 0;
                        break;
                    }
                }
                if (flag == 0)
                {
                    return -1; //chưa chứng minh được d_temp là khoảng cách hamming
                }
                else
                {//all row equal 0
                    return d_temp; //đây chính là khoảng cách hamming cần tìm
                }
            }
            else
            {
                for (int i = column_current; i < n; i++)
                {
                    var temp = new Matrix_Binary(sum_before.GetM(), 1);
                    for (int j = 0; j < sum_before.GetM(); j++)
                    {
                        temp.SetValue(j, 0, sum_before.GetValue(j, 0) ^ matrix[j, i]);
                    }
                    var result = Sum_next(temp, d_temp, column_current + 1);
                    if (result == d_temp)
                    {
                        return d_temp;
                    }
                }
                return -1;
            }
        }

        public int GetM()
        {
            return m;
        }

        public int GetN()
        {
            return n;
        }

        public Matrix_Binary ConvertTo_Standard_Form()
        {
            if (m > n)
            {
                throw new Exception("row number less than column number");
            }
            Matrix_Binary temp = new Matrix_Binary(m, n);
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp.SetValue(i, j, matrix[i, j]);
                }
            }
            for (int k = 0; k < m; k++)
            {
                for (int i = 0; i < m; i++)
                {
                    if (temp.GetValue(i, k) == 1 && i != k)
                    {
                        // row i - row k
                        for (int j = k; j < n; j++)
                        {
                            temp.SetValue(i, j, temp.GetValue(i, j) ^ temp.GetValue(k, j));
                        }
                    }
                }
            }
            return temp;
        }

        public bool IsVector_Zero()
        {
            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if(matrix[i,j] != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool Equal(Matrix_Binary second)
        {
            if((this.m == second.GetM()) && (this.n == second.GetN()))
            {
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (matrix[i, j] != second.GetValue(i,j))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
