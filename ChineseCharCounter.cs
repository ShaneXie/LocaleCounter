using System;
using System.Collections.Generic;

namespace ECounter
{
    public class ChineseCharCounter : CharCounter
    {
        public ChineseCharCounter() { }
        public ChineseCharCounter(int startNum, int endNum) : base(startNum, endNum)
        {

        }
        protected override string numToWords(int number)
        {
            string words = numToEnglishWords(number);
            Log.info($"{number} in Chinese words: {words}");
            return words;
        }

        /// <summary>
        /// recursive funtion to translate number to english word
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string numToEnglishWords(int number)
        {
            if (number == 0)
                return "零";

            if (number < 0)
                return "负 " + numToEnglishWords(Math.Abs(number));

            string words = "";

            if ((number / 100000000) > 0)
            {
                words += numToEnglishWords(number / 100000000) + "亿";
                number %= 100000000;
            }

            if ((number / 10000) > 0)
            {
                words += numToEnglishWords(number / 10000) + "万";
                number %= 10000;
            }

            if ((number / 1000) > 0)
            {
                words += numToEnglishWords(number / 1000) + "千";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += numToEnglishWords(number / 100) + "百";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "零";

                var unitsMap = new[] { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "十一", "十二", "十三", "十四", "十五", "十六", "十七", "十八", "十九" };
                var tensMap = new[] { "零", "十", "二十", "三十", "四十", "五十", "六十", "七十", "八十", "九十" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
