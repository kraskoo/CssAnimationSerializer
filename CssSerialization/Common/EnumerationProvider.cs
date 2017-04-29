namespace Common
{
    using System;
    using System.Globalization;

    public sealed class EnumerationProvider<T>
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private static readonly Lazy<EnumerationProvider<T>> LazyInstance =
            new Lazy<EnumerationProvider<T>>(() => new EnumerationProvider<T>());

        private static EnumerationProvider<T> instance;

        private EnumerationProvider(IFormatProvider provider)
        {
            this.FormatProvider = provider;
            instance = default(EnumerationProvider<T>);
        }

        private EnumerationProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        public IFormatProvider FormatProvider { get; }

        public static EnumerationProvider<T> Create()
        {
            return instance ?? LazyInstance.Value;
        }
    }
}