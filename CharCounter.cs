using System;
using System.Collections.Generic;

namespace ECounter
{
    public abstract class CharCounter
    {
        private int? startNum;
        private int? endNum;
        protected char? charToCount;

        public CharCounter()
        {

        }

        public CharCounter(int startNum, int endNum, char charToCount)
        {
            SetRange(startNum, endNum);
            SetChar(charToCount);
        }

        public CharCounter SetRange(int startNum, int endNum)
        {
            if (startNum < Config.COUNTER_RANGE_MIN)
                throw new CounterRangeException($"Start number can not less than {Config.COUNTER_RANGE_MIN}");
            if (endNum > Config.COUNTER_RANGE_MAX)
                throw new CounterRangeException($"End number can not greater than {Config.COUNTER_RANGE_MAX}");
            if (startNum >= endNum)
                throw new CounterRangeException($"Start number must less than End number");

            this.startNum = startNum;
            this.endNum = endNum;
            return this;
        }

        public CharCounter SetChar(char charToCount)
        {
            this.charToCount = charToCount;
            return this;
        }


        public Dictionary<int, int> Count
        {
            get
            {
                return doCount();
            }
        }

        private Dictionary<int, int> doCount()
        {
            if (startNum == null || endNum == null)
                throw new CounterRangeException("Range not set");

            if (startNum == null || endNum == null)
                throw new CounterCharNotSetException();

            Dictionary<int, int> countDict = new Dictionary<int, int>();

            for (int num = startNum.Value; num <= endNum; num++)
            {
                countDict.Add(num, charCount(num));
            }

            return countDict;
        }

        private int charCount(int number)
        {
            int count = 0;
            string numStr = numToWords(number);
            foreach (char c in numStr)
                if (c == charToCount)
                    count++;
            Console.WriteLine($"number of {charToCount}: {count}");
            return count;
        }

        protected abstract string numToWords(int number);
    }
}
