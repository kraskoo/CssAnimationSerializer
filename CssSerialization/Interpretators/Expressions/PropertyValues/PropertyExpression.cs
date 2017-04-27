namespace Interpretators.Expressions.PropertyValues
{
    using System;

    public abstract class PropertyExpression<TProp> : IdentifierExpression<TProp>
        where TProp : IConvertible
    {
        protected PropertyExpression(
            TProp representation) : base(representation)
        {
        }
    }
}