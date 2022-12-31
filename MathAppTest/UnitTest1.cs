using MathApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace MathAppTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test_Add()
        {
            MyMath math = new MyMath();
            double r = math.Add(10, 2);
            Assert.AreEqual(12, r);
        }

        [DataTestMethod]
        [DataRow(10, 2, 8)]
        [DataRow(10, 10, 0)]
        [DataRow(10, -10, 20)]
        public void Test_Subtract(double x, double y, double exp)
        {
            MyMath math = new MyMath();
            double r = math.Subtract(x, y);
            Assert.AreEqual(r, exp);
        }


        [DataTestMethod]
        [DataRow(10, 2, 20)]
        [DataRow(10, -10, -100)]
        [DataRow(10, 0, 0)]
        [DynamicData(nameof(MulData), DynamicDataSourceType.Method)]
        public void Test_Multiply(double x, double y, double exp)
        {
            MyMath math = new MyMath();
            double r = math.Multiply(x, y);
            Assert.AreEqual(r, exp);
        }


        [DataTestMethod]
        [DataRow(10, 2, 5)]
        [DataRow(10, -10, -1)]
        [DataRow(10, 1, 10)]
        public void Test_Divide(double x, double y, double exp)
        {
            MyMath math = new MyMath();
            double r = math.Divide(x, y);
            Assert.AreEqual(r, exp);
        }

        private static IEnumerable<object[]> MulData()
        {
            //return
            //    new[]
            //    {
            //        new object[] {20,2,40 },
            //        new object[] {2,-2,-4 },
            //        new object[] {0,0,0 }
            //    };
            using (StreamReader sr = File.OpenText(@"H:\test.txt"))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] t = s.Split(',');
                    object[] c = new object[t.Length];
                    for (int i = 0; i < c.Length; i++)
                    {
                        c[i] = Convert.ToDouble(t[i]);
                    }
                    yield return c;
                }
            }
        }
    }
}
