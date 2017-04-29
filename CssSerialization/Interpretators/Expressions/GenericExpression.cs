namespace Interpretators.Expressions
{
    using System;
    using System.Globalization;
    using Interfaces;

    public abstract class GenericExpression<TParam> : Expression
        where TParam : IConvertible
    {
        protected GenericExpression(TParam representation)
        {
            this.Representation = representation;
        }

        protected TParam Representation { get; }

        public override void Interpret(IContext context)
        {
            var previouses = this.GetPrevious();
            foreach (var previous in previouses)
            {
                previous.Interpret(context);
            }

            context.Append(
                this.Representation
                    .ToString(CultureInfo.CurrentCulture));
            var nexts = this.GetNexts();
            foreach (var next in nexts)
            {
                next.Interpret(context);
            }
        }

        public override string ToString()
        {
            return this.GetType().Name;
        }
    }
}