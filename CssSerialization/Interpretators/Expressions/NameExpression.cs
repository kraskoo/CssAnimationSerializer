namespace Interpretators.Expressions
{
    using System;

    public abstract class NameExpression<TParam> : GenericExpression<TParam>
        where TParam : IConvertible
    {
        protected NameExpression(TParam representation) : base(representation)
        {
        }
    }
}