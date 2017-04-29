//namespace Interpretators.Expressions
//{
//    using System;
//    using Interfaces;
//    using SyntaxParticularityValues;

//    public class IterationCountExpression : IdentifierExpression<int>
//    {
//        private readonly int minValue;
//        private readonly int maxValue;

//        public IterationCountExpression(
//            int representation,
//            int minValue = int.MinValue,
//            int maxValue = int.MaxValue) : base(
//                representation)
//        {
//            this.ValidateRange(representation);
//            this.minValue = minValue;
//            this.maxValue = maxValue;
//        }

//        public override void Interpret(IContext context)
//        {
//            var nameExpression = new NameExpression("pesho");
//            nameExpression.Interpret(context);
//            new ValueEqualitySign().Interpret(context);
//            context.Append($"{this.Representation}");
//            new SemicolonExpression().Interpret(context);
//        }

//        private void ValidateRange(int currentValue)
//        {
//            this.ValidateMinRange(currentValue);
//            this.ValidateMaxRange(currentValue);
//        }

//        private void ValidateMaxRange(int currentValue)
//        {
//            if (currentValue > this.maxValue)
//            {
//                throw new ArgumentOutOfRangeException(nameof(currentValue));
//            }
//        }

//        private void ValidateMinRange(int currentValue)
//        {
//            if (currentValue < this.minValue)
//            {
//                throw new ArgumentOutOfRangeException(nameof(currentValue));
//            }
//        }
//    }
//}