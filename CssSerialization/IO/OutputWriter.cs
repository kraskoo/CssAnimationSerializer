namespace IO
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Interfaces;

    public abstract class OutputWriter : IOutputWriter
    {
        private TextWriter writer;

        protected OutputWriter(TextWriter writer)
        {
            this.writer = writer;
        }

        public void Write(string format, params object[] parameters)
        {
            this.writer.Write(format, parameters);
        }

        public void Write(string message)
        {
            this.writer.Write(message);
        }

        public async Task WriteAsync(string format, params object[] parameters)
        {
            await this.writer.WriteAsync(string.Format(format, parameters));
        }

        public async Task WriteAsync(string message)
        {
            await this.writer.WriteAsync(message);
        }

        public void WriteLine()
        {
            this.writer.WriteLine();
        }

        public void WriteLine(string format, params object[] parameters)
        {
            this.writer.WriteLine(format, parameters);
        }

        public void WriteLine(string message)
        {
            this.writer.WriteLine(message);
        }

        public async Task WriteLineAsync()
        {
            await this.writer.WriteLineAsync();
        }

        public async Task WriteLineAsync(string message)
        {
            await this.writer.WriteLineAsync(message);
        }

        public async Task WriteLineAsync(string format, params object[] parameters)
        {
            await this.writer.WriteLineAsync(string.Format(format, parameters));
        }

        public void Dispose()
        {
            this.writer?.Dispose();
            this.writer = null;
            GC.SuppressFinalize(this);
        }
    }
}