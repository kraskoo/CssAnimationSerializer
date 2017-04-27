namespace IO.ConsoleInputOutput
{
    using System;
    using System.IO;

    public class ConsoleWriter : OutputWriter
    {
        public ConsoleWriter(TextWriter writer) : base(writer)
        {
        }

        public ConsoleWriter() : this(Console.Out)
        {
        }
    }
}