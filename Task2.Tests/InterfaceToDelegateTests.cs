using NUnit.Framework;
using static Task2.InterfaceToDelegate;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.Subsidiary;

namespace Task2.Tests
{
    [TestFixture()]
    public class InterfaceToDelegateTests
    {

        public int[][] ArrForFirstTest = new[]
            {
                new []{6, -5, 3, 0, 10},
                new []{1, 2, 1, 0, 1},
                new []{0, 2, 0, 0, 30, 0},
                new []{0, 2, 0, 29, -1}
            };

        public int[][] ArrNewInts = new[]
            {
                new []{0, 2, 0, 0, 30, 0},
                new []{0, 2, 0, 29, -1},
                new []{6, -5, 3, 0, 10},
                new []{1, 2, 1, 0, 1}
            };


        [Test()]
        public void SortTest()
        {
            Sort(ArrForFirstTest, new SumDown());
            Assert.AreEqual(ArrForFirstTest, ArrNewInts);
        }
    }
}