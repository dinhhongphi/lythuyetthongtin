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

        [TestMethod]
        public void ConvertTo_Standard_Form_Test_valid()
        {
            Matrix_Binary matrix2 = new Matrix_Binary(4, 7)
            {
                matrix = new int[4, 7]
                {
                    {1,1,0,1,0,0,0 },
                    {1,0,1,1,1,0,0},
                    {0,1,0,0,0,1,1 },
                    {1,0,1,0,0,0,1 }
                }
            };

            var a = matrix2.ConvertTo_Standard_Form();
            int[,] expected = new int[4, 7]
            {
                {1,0,0,0,1,1,0 },
                {0,1,0,0,0,1,1 },
                {0,0,1,0,1,1,1 },
                {0,0,0,1,1,0,1 }
            };
            CollectionAssert.AreEqual(expected, a.matrix);
        }
        [TestMethod]
        public void GetHammingDistance_Test_valid()
        {
            Matrix_Binary h = new Matrix_Binary(3, 7)
            {
                matrix = new int[3, 7]
                {
                    {1,0,0,1,0,1,1 },
                    {0,1,0,1,1,1,0 },
                    {0,0,1,0,1,1,1 }
                }
            };

            var result = h.GetHammingDistance();
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Get_Matrix_Chuyen_vi_Test_valid()
        {
            Matrix_Binary a = new Matrix_Binary(2, 3)
            {
                matrix = new int[2, 3]
                {
                    {1,0,0 },
                    {0,1,1 }
                }
            };
            var result = a.Get_Matrix_Chuyen_vi();
            int[,] expect = new int[3, 2]
            {
                {1,0 },
                {0,1 },
                {0,1 }
            };
            CollectionAssert.AreEqual(expect, result.matrix);
        }

        [TestMethod]
        public void GetMatrix_Check_Test()
        {
            Matrix_Binary x = new Matrix_Binary(4, 7)
            {
                matrix = new int[4, 7]
                {
                    {1,0,0,0,1,1,0 },
                    {0,1,0,0,0,1,1 },
                    {0,0,1,0,1,1,1 },
                    {0,0,0,1,1,0,1 }
                }
            };
            var result = x.GetMatrix_Check();
            int[,] expect = new int[3, 7]
            {
                {1,0,1,1,1,0,0 },
                {1,1,0,1,0,1,0 },
                {0,1,1,1,0,0,1 }
            };

            CollectionAssert.AreEqual(expect, result.matrix);
        }
    }
}
