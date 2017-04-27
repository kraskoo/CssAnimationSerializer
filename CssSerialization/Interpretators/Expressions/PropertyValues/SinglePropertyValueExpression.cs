namespace Interpretators.Expressions.PropertyValues
{
    using System;

    public class SinglePropertyValueExpression<TProp> : PropertyExpression<TProp>
        where TProp : IConvertible
    {
        public SinglePropertyValueExpression(
            TProp representation) : base(
                representation)
        {
        }
    }
}