using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksu.Cis300.LinkedListLibrary;
using Ksu.Cis300.Nim;

namespace UnitTestProject1
{
    [TestClass]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class UnitTests
    {
        Board b;
        Dictionary<int?, char> dic;
        char val;

        [TestInitialize]
        public void SetUp()
        {
            dic = new Dictionary<int?, char>();
            b = new Board(new int[] { 10, 12, 13, 14 }, new int[] { 5, 5, 5, 5 });

        }

        //Tests for Board Class
        [TestMethod]
        public void boardNumberOfPilestest()
        {
            Assert.AreEqual(b.NumberOfPiles, 4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Not equal Piles/Limits")]
        public void boardConstructBadTest()
        {
            Board badB = new Board(new int[] { 10, 12, 13, 14 }, new int[] { 5, 5, 5 });
        }

        [TestMethod]
        public void boardMakePlaytest()
        {
            Play p = new Play(1, 3);
            b = b.MakePlay(p);
            Console.Write(b.GetValue(1));
            Assert.AreEqual(9, b.GetValue(1));
        }

        [TestMethod]
        public void boardMakePlayLimittest()
        {
            Play p = new Play(3, 3);
            b = b.MakePlay(p);
            Assert.AreEqual(6, b.GetLimit(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Pulling too many rocks")]
        public void boardMakeBadPlaytest()
        {
            Play p = new Play(18, 6);
            b = b.MakePlay(p);
        }

        [TestMethod]
        public void boardGetLimitGoodTest()
        {
            Assert.AreEqual(5, b.GetLimit(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "pile doesn't exist")]
        public void boardGetLimitBadTest()
        {
            int x = b.GetLimit(-1);
        }



        [TestMethod]
        public void boardGetValueGoodTest()
        {
            Assert.AreEqual(14, b.GetValue(3));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "pile doesn't exist")]
        public void boardGetValueBadTest()
        {
            int x = b.GetValue(-1);
        }

        //Tests for Play Class

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "what r u doin")]
        public void playInvalidPlayTest()
        {
            Play p = new Play(-234365, -69);
        }

        //Tests for LinkedListCell Class

        [TestMethod]
        public void linkedListDataTest()
        {
            LinkedListCell<int> llcell = new LinkedListCell<int>();
            llcell.Data = 5;
            Assert.AreEqual(llcell.Data, 5);
        }

        [TestMethod]
        public void linkedListNextTest()
        {
            LinkedListCell<int> cellOne = new LinkedListCell<int>();
            LinkedListCell<int> cellTwo = new LinkedListCell<int>();
            cellOne.Next = cellTwo;
            Assert.AreEqual(cellOne.Next, cellTwo);
        }

        [TestMethod]
        public void dictionaryTryGetValueAddTest()
        {
            dic.Add(5, 'k');
            dic.TryGetValue(5, out val);
            Assert.AreEqual(val, 'k');

        }

        [TestMethod]
        public void dictionaryTryGetBadValueAddTest()
        {
            dic.Add(5, 'g');
            dic.TryGetValue(5, out val);
            Assert.AreNotEqual(val, 'k');
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Bad key or value")]
        public void dictionaryTryGetExceptionValueAddTest()
        {
            dic.Add(1, 's');
            dic.Add(1, 's');
        }

        [TestMethod]
        public void dictionaryExceedOriginalSize()
        {
            Dictionary<int, char> dic = new Dictionary<int, char>();
            for (int i = 0; i < 200; i++) dic.Add(i, (char)i);

            if (dic.TryGetValue(199, out val))
            {
                Assert.AreEqual(val, (char)199);
            }
            else
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Bad key or value")]
        public void dictionaryTryGetExceptionBadKey()
        {
            dic.Add(null, 's');
        }

        [TestMethod]
        public void dictionaryTryGetInvalidKey()
        {
            if (dic.TryGetValue(0, out val))
            {
                Assert.Fail();
            }
            else
            {
                Assert.AreEqual(val, default(char));
            }
        }
    }
}
