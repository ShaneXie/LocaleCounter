using System;

namespace ECounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = (new LocaleCharCounter()).Counter;
            counter.SetRange(5, 12);
            CharCounter.PrintDict(counter.Count('e'));

            var counter2 = (new LocaleCharCounter(5, 12)).Counter;
            CharCounter.PrintDict(counter2.Count('e'));
            CharCounter.PrintDict(counter.SetRange(1, 3).Count('e'));
        }
    }
}
