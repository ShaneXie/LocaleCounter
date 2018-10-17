using System;

namespace ECounter
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = (new LocaleCharCounter()).Counter;
            counter.SetRange(901, 921).SetChar('十');
            Console.WriteLine(counter.Count);
        }
    }
}
