using System;
using Moq;

namespace SticksGame
{
    public class ConsoleWrapper
    {
        public virtual void WriteLine(string str)
        {
            Console.WriteLine(str);
        }
    }
}
