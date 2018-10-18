using System;
using System.Collections.Generic;

namespace ECounter
{
    public class EnglishCharCounter : CharCounter
    {
        public EnglishCharCounter() { }
        public EnglishCharCounter(int startNum, int endNum) : base(startNum, endNum)
        {

        }
        protected override string numToWords(int number)
        {
            string words = numToEnglishWords(number);
            Log.info($"{number} in English words: {words}");
            return words;
        }

        private static string numToEnglishWords(int number)
        {
            if (number == 0)
                return "zero";

            if (number < 0)
                return "minus " + numToEnglishWords(Math.Abs(number));

            string words = "";

            if ((number / 1000000) > 0)
            {
                words += numToEnglishWords(number / 1000000) + " million ";
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words += numToEnglishWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += numToEnglishWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";

                var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
                var tensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };

                if (number < 20)
                    words += unitsMap[number];
                else
                {
                    words += tensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + unitsMap[number % 10];
                }
            }

            return words;
        }
    }
}
