namespace Common
{
    using System;
    using System.Globalization;

    public sealed class EnumerationProvider<T>
        where T : struct, IComparable, IFormattable, IConvertible
    {
        private static readonly Lazy<EnumerationProvider<T>> LazyInstance =
            new Lazy<EnumerationProvider<T>>(() => new EnumerationProvider<T>());

        private EnumerationProvider(IFormatProvider provider)
        {
            this.FormatProvider = provider;
            Instance = default(EnumerationProvider<T>);
        }

        public static EnumerationProvider<T> Instance { get; private set; }

        private EnumerationProvider() : this(CultureInfo.CurrentCulture)
        {
        }

        public IFormatProvider FormatProvider { get; }

        public static EnumerationProvider<T> Create()
        {
            return Instance ?? LazyInstance.Value;
        }
    }
}