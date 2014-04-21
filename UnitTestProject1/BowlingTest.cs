using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class BowlingTest
    {
        Bowling game = null;

        [TestInitialize]
        public void SetUp()
        {
            game = new Bowling();
        }

        private void RollMany(int rolls, int pins)
        {
            for (int i = 0; i < rolls; i++)
            {
                game.Roll(pins);
            }
        }

        [TestMethod]
        public void GutterGameScoreMustBe_0()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, game.Score());
        }


        [TestMethod]
        public void OnePinGamesMustScore_20()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void SpareBonusMustBeAdded()
        {
            game.Roll(5);
            game.Roll(5);
            RollMany(18, 1);
            Assert.AreEqual(5 + 5 + 1 + 18 * 1, game.Score());
        }

        [TestMethod]
        public void StrikeBonusMustBeAdded()
        {
            game.Roll(10);
            RollMany(18, 1);
            Assert.AreEqual(10 + 1 + 1 + 18 * 1, game.Score());
        }

        [TestMethod]
        public void PerfectGameMustScore_300()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }

    }

}
