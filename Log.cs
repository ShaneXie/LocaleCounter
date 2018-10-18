using System;

namespace ECounter
{
    sealed class Log
    {
        static public void info(string text)
        {
            if (Config.IS_DEV)
            {
                Console.WriteLine(text);
            }
        }
    }
}