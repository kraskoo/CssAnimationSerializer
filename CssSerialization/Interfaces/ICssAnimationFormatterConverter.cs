namespace Interfaces
{
    using System;

    public interface ICssAnimationFormatterConverter
    {
        T Convert<T>(T value, Type type);

        object Convert(object value, Type type);
    }
}