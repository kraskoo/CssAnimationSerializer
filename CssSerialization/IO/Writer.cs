namespace IO
{
    using System.IO;

    public class Writer : OutputWriter
    {
        public Writer(TextWriter writer) : base(writer)
        {
        }

        public TextWriter Out => this.Writer;
    }
}