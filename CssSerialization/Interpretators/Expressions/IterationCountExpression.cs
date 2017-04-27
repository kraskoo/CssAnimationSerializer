namespace Interpretators.Expressions
{
    using System;
    using Interfaces;
    using SyntaxParticularityValues;

    public class IterationCountExpression : IdentifierExpression<int>
    {
        private readonly NameExpression name;
        private readonly int minValue;
        private readonly int maxValue;

        public IterationCountExpression(
            NameExpression name,
            int representation,
            int minValue = int.MinValue,
            int maxValue = int.MaxValue) : base(
                representation)
        {
            this.name = name;
            this.ValidateRange(representation);
            this.minValue = minValue;
            this.maxValue = maxValue;
        }

        public override void Interpret(IContext context)
        {
            this.name.Interpret(context);
            new ValueEqualitySign().Interpret(context);
            context.Append($"{this.Representation}");
            new SemicolonExpression().Interpret(context);
        }

        private void ValidateRange(int currentValue)
        {
            this.ValidateMinRange(currentValue);
            this.ValidateMaxRange(currentValue);
        }

        private void ValidateMaxRange(int currentValue)
        {
            if (currentValue > this.maxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(currentValue));
            }
        }

        private void ValidateMinRange(int currentValue)
        {
            if (currentValue < this.minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(currentValue));
            }
        }
    }
}