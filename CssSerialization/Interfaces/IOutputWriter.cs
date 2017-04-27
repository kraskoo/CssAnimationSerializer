namespace Interfaces
{
    using System;
    using System.Threading.Tasks;

    public interface IOutputWriter : IDisposable
    {
        void Write(string format, params object[] parameters);

        void Write(string message);

        Task WriteAsync(string format, params object[] parameters);

        Task WriteAsync(string message);

        void WriteLine();

        void WriteLine(string format, params object[] parameters);

        void WriteLine(string message);

        Task WriteLineAsync();

        Task WriteLineAsync(string message);

        Task WriteLineAsync(string format, params object[] parameters);
    }
}