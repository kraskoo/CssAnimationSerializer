namespace IO
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Interfaces;

    public abstract class InputReader : IInputReader
    {
        private TextReader reader;

        protected InputReader(TextReader inputReader)
        {
            this.reader = inputReader;
        }

        public string ReadLine()
        {
            return this.reader.ReadLine();
        }

        public async Task<string> ReadLineAsync()
        {
            return await this.reader.ReadLineAsync();
        }

        public string ReadToEnd()
        {
            return this.reader.ReadToEnd();
        }

        public async Task<string> ReadToEndAsync()
        {
            return await this.reader.ReadToEndAsync();
        }

        public byte[] ReadBytes()
        {
            var text = this.ReadToEnd();
            byte[] bytes = new byte[text.Length];
            for (int i = 0; i < text.Length; i++)
            {
                bytes[i] = Convert.ToByte(text[i]);
            }

            return bytes;
        }

        public async Task<byte[]> ReadBytesAsync()
        {
            var text = this.ReadToEndAsync().Result;
            var bytes = new byte[text.Length];
            return await Task.Run(() =>
            {
                int index = -1;
                foreach (var character in text)
                {
                    bytes[++index] = Convert.ToByte(character);
                }

                return bytes;
            });
        }

        public void Dispose()
        {
            this.reader?.Dispose();
            this.reader = null;
            GC.SuppressFinalize(this);
        }
    }
}