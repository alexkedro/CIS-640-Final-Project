using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ksu.Cis300.LinkedListLibrary;
using Ksu.Cis300.Nim;


namespace UnitTestProject1
{

    [TestClass]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverage]
    public class IntegrationTests
    {
        [TestMethod]
        public void Dictionary_Full_Test()
        {
            Dictionary<int?, string> dic = new Dictionary<int?, string>();
            string output;

            dic.Add(0, "Zero");
            for (int i = 1; i < 200; i++) dic.Add(i, "loop" + i);

            if (dic.TryGetValue(0, out output)) Assert.AreEqual(output, "Zero", false);
            else Assert.Fail();

            try
            {
                dic.Add(null, "null");
                Assert.Fail();
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsNotNull(ex);
            }

            if (dic.TryGetValue(201, out output)) Assert.Fail();
            else Assert.AreEqual(output, default(string));

            try
            {
                dic.Add(0, "zero fail");
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }
        }

        [TestMethod]
        public void Play_and_Board_Full_Test()
        {
            Board board = new Board(new int[] { 3, 3, 3 }, new int[] { 1, 1, 1 });
            Board board2 = new Board(new int[] { 3, 3, 3 }, new int[] { 1, 1, 1 });

            try
            {
                Board fail = new Board(new int[] { 3, 3, 3 }, new int[] { 1, 1, 1, 1 });
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }

            Play valid_play = new Play(2, 1);
            Play invalid_play = new Play(5, 5);

            try
            {
                Play fail = new Play(-1, 0);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }

            Assert.AreEqual(2, valid_play.Pile);
            Assert.AreEqual(1, valid_play.Number);

            Assert.AreEqual(3, board.NumberOfPiles);

            board = board.MakePlay(valid_play);

            Assert.AreEqual(board.GetValue(2), 2);
            Assert.AreEqual(board.GetLimit(2), 2);

            if (board != board2) board2 = null;
            else Assert.Fail();
            
            try
            {
                board.MakePlay(invalid_play);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }

            try
            {
                board.GetValue(-1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }

            try
            {
                board.GetLimit(-1);
                Assert.Fail();
            }
            catch (ArgumentException ex)
            {
                Assert.IsNotNull(ex);
            }


            if (board == board2) Assert.Fail();
            else board = null;

            if (board != board2) Assert.Fail();
            else
            {
                board = new Board(new int[] { 3, 3, 3 }, new int[] { 1, 1, 1 });
                board2 = new Board(new int[] { 3, 3, 3 ,3 }, new int[] { 1, 1, 1, 1 });
            }

            if (board == board2) Assert.Fail();
            else board2 = new Board(new int[] { 3, 3, 3 }, new int[] { 1, 1, 1 });

            if (board.Equals(board2)) Assert.IsNotNull(board.GetHashCode());
            else Assert.Fail();

            if (board.Equals(valid_play)) Assert.Fail();

        }
    }
}
