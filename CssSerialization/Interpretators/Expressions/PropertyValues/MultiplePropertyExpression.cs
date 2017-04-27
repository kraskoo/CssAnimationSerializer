namespace Interpretators.Expressions.PropertyValues
{
    using System;
    using Interfaces;

    public class MultiplePropertyValueExpression<TProp> : PropertyExpression<TProp>
        where TProp : IConvertible
    {
        public MultiplePropertyValueExpression(
            TProp representation,
            params IExpression[] otherValues) : base(
                representation)
        {
            this.OtherValues = otherValues;
        }

        protected IExpression[] OtherValues { get; }
    }
}