using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnitTestProject1
{
    class Bowling
    {
        private List<int> scores = new List<int>();

        public void Roll(int pins)
        {
            scores.Add(pins);
        }

        public int Score()
        {

            List<int> saveCopy = new List<int>(scores);
            return saveCopy.Select((pins, index) => pins += AddBonusPins(index))
                .Aggregate((score, pins) => score += pins);
        }

        private int AddBonusPins(int roll)
        {
            if (NotLastFrame(roll))
            {
                if (IsStrike(roll))
                {
                    return StrikeBonus(roll);
                }
                else if (IsSpare(roll))
                {
                    return SpareBonus(roll);
                }
            }
            return 0;
        }

        private bool NotLastFrame(int roll)
        {
            return roll < scores.Count() - 3;
        }

        private int Sum(int roll)
        {
            return scores[roll] + scores[roll + 1];
        }

        private int SpareBonus(int roll)
        {
            return scores[roll + 2];
        }

        private int StrikeBonus(int roll)
        {
            return scores[roll + 1] + scores[roll + 2];
        }

        private bool IsSpare(int roll)
        {
            return 10 == scores[roll] + scores[roll + 1];
        }

        private bool IsStrike(int roll)
        {
            return 10 == scores[roll];
        }
    }
}
