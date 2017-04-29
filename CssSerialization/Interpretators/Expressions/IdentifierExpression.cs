namespace Interpretators.Expressions
{
    using System;

    public abstract class IdentifierExpression<TParam> : GenericExpression<TParam>
        where TParam : IConvertible
    {
        protected IdentifierExpression(TParam representation) : base(representation)
        {
        }
    }
}