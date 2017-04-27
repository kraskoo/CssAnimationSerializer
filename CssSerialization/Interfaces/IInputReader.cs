namespace Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IInputReader : IDisposable
    {
        string ReadLine();

        Task<string> ReadLineAsync();

        string ReadToEnd();

        Task<string> ReadToEndAsync();

        byte[] ReadBytes();

        Task<byte[]> ReadBytesAsync();
    }
}