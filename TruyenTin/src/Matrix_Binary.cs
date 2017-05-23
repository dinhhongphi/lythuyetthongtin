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
            if(value == 0 || value == 1)
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
            if(this.n == second.GetM()) //thỏa điều kiện nhân hai ma trận
            {
                Matrix_Binary c = new Matrix_Binary(this.m, second.GetN());

                for(int i = 0; i < c.GetM(); i++)
                {
                    for(int j = 0; j < c.GetN(); j++)
                    {
                        int result = 0;
                        for(int k = 0; k < this.n; k++)
                        {
                            result ^= this.matrix[i, k] * second.GetValue(k, j);
                        }
                        c.SetValue(i,j,result);
                    }
                }
                return c;
            }else
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
            return null;
        }

        /// <summary>
        /// Caculator hamming distance
        /// </summary>
        /// <returns></returns>
        public int GetHammingDistance()
        {
            return 1;
        }

        public int GetM()
        {
            return m;
        }

        public int GetN()
        {
            return n;
        }
    }
}
