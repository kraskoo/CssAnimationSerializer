namespace Interpretators.Expressions
{
    using System;
    using System.Globalization;
    using Interfaces;

    public abstract class IdentifierExpression<TParam> : IExpression
        where TParam : IConvertible
    {
        protected IdentifierExpression(TParam representation)
        {
            this.Representation = representation;
        }

        public virtual void Interpret(IContext context)
        {
            context.Append(
                this.Representation
                    .ToString(CultureInfo.CurrentCulture));
        }

        protected TParam Representation { get; set; }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}