namespace IO
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Interfaces;

    public abstract class OutputWriter : IOutputWriter
    {
        protected OutputWriter(TextWriter writer)
        {
            this.Writer = writer;
        }

        protected TextWriter Writer { get; private set; }

        public void Write(string format, params object[] parameters)
        {
            this.Writer.Write(format, parameters);
        }

        public void Write(string message)
        {
            this.Writer.Write(message);
        }

        public async Task WriteAsync(string format, params object[] parameters)
        {
            await this.Writer.WriteAsync(string.Format(format, parameters));
        }

        public async Task WriteAsync(string message)
        {
            await this.Writer.WriteAsync(message);
        }

        public void WriteLine()
        {
            this.Writer.WriteLine();
        }

        public void WriteLine(string format, params object[] parameters)
        {
            this.Writer.WriteLine(format, parameters);
        }

        public void WriteLine(string message)
        {
            this.Writer.WriteLine(message);
        }

        public async Task WriteLineAsync()
        {
            await this.Writer.WriteLineAsync();
        }

        public async Task WriteLineAsync(string message)
        {
            await this.Writer.WriteLineAsync(message);
        }

        public async Task WriteLineAsync(string format, params object[] parameters)
        {
            await this.Writer.WriteLineAsync(string.Format(format, parameters));
        }

        public void Dispose()
        {
            this.Writer?.Dispose();
            this.Writer = null;
            GC.SuppressFinalize(this);
        }
    }
}