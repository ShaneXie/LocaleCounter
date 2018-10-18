using System;

namespace ECounter
{
    /// <summary>
    /// LocaleCharCounter Factory
    /// </summary>
    class LocaleCharCounter
    {
        private CharCounter counter;

        public LocaleCharCounter() : this(null, null, Config.LOCALE) { }
        public LocaleCharCounter(int? startNum, int? endNum) : this(startNum, endNum, Config.LOCALE) { }
        public LocaleCharCounter(int? startNum, int? endNum, string locale)
        {
            this.counter = createCounterByLocale(startNum, endNum, locale);
        }

        public CharCounter Counter
        {
            get
            {
                return counter;
            }
        }

        /// <summary>
        /// creater function to create CharCounter instance
        /// </summary>
        /// <param name="startNum"></param>
        /// <param name="endNum"></param>
        /// <param name="locale"></param>
        /// <returns></returns>
        private CharCounter createCounterByLocale(int? startNum, int? endNum, string locale)
        {
            bool withRange = startNum != null && endNum != null;
            CharCounter charCounter = withRange ?
                new EnglishCharCounter(startNum.Value, endNum.Value) :
                new EnglishCharCounter();

            switch (locale)
            {
                case "en":
                    break;
                case "zh":
                    charCounter = withRange ?
                        new ChineseCharCounter(startNum.Value, endNum.Value) :
                        new ChineseCharCounter();
                    break;
                default:
                    break;
            }
            return charCounter;
        }
    }
}
