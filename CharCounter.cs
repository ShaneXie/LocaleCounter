using System;
using System.Collections.Generic;

namespace ECounter
{
    /// <summary>
    /// Base CharCounter abstract class
    /// </summary>
    public abstract class CharCounter
    {
        private int? startNum;
        private int? endNum;

        public CharCounter()
        {

        }

        public CharCounter(int startNum, int endNum)
        {
            SetRange(startNum, endNum);
        }

        /// <summary>
        /// Set and validate range
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="endNum"></param>
        /// <returns></returns>
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

        /// <summary>
        /// loop thru number range and count the char
        /// return the result dictionary
        /// </summary>
        /// <param name="ch"></param>
        /// <returns></returns>
        public Dictionary<int, int> Count(char ch)
        {
            if (startNum == null || endNum == null)
                throw new CounterRangeException("Range not set");

            if (startNum == null || endNum == null)
                throw new CounterCharNotSetException();

            Dictionary<int, int> countDict = new Dictionary<int, int>();

            for (int num = startNum.Value; num <= endNum; num++)
            {
                countDict.Add(num, charCount(num, ch));
            }

            return countDict;
        }

        /// <summary>
        /// translate number to words and count
        /// </summary>
        /// <param name="number"></param>
        /// <param name="ch"></param>
        /// <returns></returns>
        private int charCount(int number, char ch)
        {
            int count = 0;
            string numStr = numToWords(number);
            foreach (char c in numStr)
                if (c == ch)
                    count++;
            Log.info($"number of {ch}: {count}");
            return count;
        }

        /// <summary>
        /// abstract funtion for child to implement to translate words
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        protected abstract string numToWords(int number);

        /// <summary>
        /// static function to print a given dictionary
        /// </summary>
        /// <param name="dict"></param>
        static public void PrintDict(Dictionary<int, int> dict)
        {
            foreach (var item in dict)
            {
                Console.WriteLine($"({item.Key}, {item.Value})");
            }
        }
    }
}
