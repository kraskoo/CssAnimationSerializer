namespace Common
{
    using System;
    using System.Linq.Expressions;

    public static class EnumExtensions
    {
        public static T Get<T>(this T property)
            where T : struct, IComparable, IFormattable, IConvertible
        {
            var enumValue = (T)Enum.Parse(
                typeof(T),
                property.ToString(
                    EnumerationProvider<T>.Create().FormatProvider));
            Func<Expression<Func<T, T>>, T> funcExpression = fe => fe.Compile()(enumValue);
            return funcExpression(p => property);
        }
    }
}