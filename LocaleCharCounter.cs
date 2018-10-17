using System;

namespace ECounter
{
    /// <summary>
    /// LocaleCharCounter Factory
    /// </summary>
    class LocaleCharCounter
    {
        private CharCounter counter;

        public LocaleCharCounter() : this(Config.LOCALE) { }
        public LocaleCharCounter(string locale)
        {
            this.counter = createCounterByLocale(locale);
        }

        public CharCounter Counter
        {
            get
            {
                return counter;
            }
        }

        private CharCounter createCounterByLocale(string locale)
        {
            CharCounter charCounter;
            switch (locale)
            {
                case "en":
                    charCounter = new EnglishCharCounter();
                    break;
                case "zh":
                    charCounter = new ChineseCharCounter();
                    break;
                default:
                    charCounter = new EnglishCharCounter();
                    break;
            }
            return charCounter;
        }
    }
}
