using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSearch;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        char[,] board = new char[,] { { 'A', 'E', 'D' },
                                      { 'D', 'J', 'B' },
                                      { 'А', 'B', 'C' } };
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(Program.Exist(board, "AED"));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.IsTrue(Program.Exist(board, "AEJ"));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.IsFalse(Program.Exist(board, "DJA"));
        }

        [TestMethod]
        public void TestMethod4()
        {
            Assert.IsTrue(Program.Exist(board, "CB"));
        }

        [TestMethod]
        public void TestMethod5()
        {
            Assert.IsFalse(Program.Exist(board, "CBC"));
        }
    }
}
