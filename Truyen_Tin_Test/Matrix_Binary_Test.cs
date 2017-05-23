using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TruyenTin.src;

namespace Truyen_Tin_Test
{
    [TestClass]
    public class Matrix_Binary_Test
    {
        [TestMethod]
        public void Multiply_Test_true()
        {
            Matrix_Binary matrix = new Matrix_Binary(3, 2)
            {
                matrix = new int[3, 2]
                {
                    {1,0 },
                    {0, 0},
                    {0,1 }
                }
            };
            Matrix_Binary matrix2 = new Matrix_Binary(2, 4)
            {
                matrix = new int[2, 4]
                {
                    {0,1,1,0 },
                    {1,0,0,1},
                }
            };
            Matrix_Binary result = matrix.Multiply(matrix2);
            int[,] expected = new int[3, 4]
            {
                {0,1,1,0 },
                {0,0,0,0 },
                {1,0,0,1 }
            };
            CollectionAssert.AreEqual(expected,result.matrix);
        }

        [TestMethod]
        public void Multiply_Test_1_true()
        {
            Matrix_Binary matrix = new Matrix_Binary(1, 2)
            {
                matrix = new int[1, 2]
                {
                    {1,0 }
                }
            };
            Matrix_Binary matrix2 = new Matrix_Binary(2, 4)
            {
                matrix = new int[2, 4]
                {
                    {0,1,1,0 },
                    {1,0,0,1},
                }
            };
            Matrix_Binary result = matrix.Multiply(matrix2);
            int[,] expected = new int[1, 4]
            {
                {0,1,1,0 }
            };
            CollectionAssert.AreEqual(expected, result.matrix);
        }

        [TestMethod]
        public void Multiply_Test_Condition_to_MultiplyMatrix()
        {
            Matrix_Binary matrix = new Matrix_Binary(2,3);
            Matrix_Binary matrix2 = new Matrix_Binary(2, 5);
            var result = matrix.Multiply(matrix2);
            Assert.AreEqual(null, result);
        }
    }
}
