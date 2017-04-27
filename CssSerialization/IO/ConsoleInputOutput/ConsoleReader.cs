namespace IO.ConsoleInputOutput
{
    using System;
    using System.IO;

    public class ConsoleReader : InputReader
    {
        public ConsoleReader(TextReader inputReader) : base(inputReader)
        {
        }

        public ConsoleReader() : this(Console.In)
        {
        }
    }
}