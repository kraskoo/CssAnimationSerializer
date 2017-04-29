//namespace Interpretators.Expressions
//{
//    using System;
//    using System.Linq;
//    using Models.Enums;
//    using Models.Factories;
//    using Interfaces;
//    using SyntaxParticularityValues;

//    public class DurationExpression : IExpression
//    {
//        private readonly int duration;
//        private readonly int minDuration;
//        private readonly int maxDuration;
//        private readonly MeasurementUnitType measurementUnit;
//        private readonly MeasurementUnitType[] validUnits =
//        {
//            MeasurementUnitType.Second,
//            MeasurementUnitType.Millisecond
//        };

//        public DurationExpression(
//            int duration,
//            MeasurementUnitType measurementUnit,
//            int minDuration = int.MinValue,
//            int maxDuration = int.MaxValue)
//        {
//            this.ValidateTypeState(duration, measurementUnit);
//            this.duration = duration;
//            this.measurementUnit = measurementUnit;
//            this.minDuration = minDuration;
//            this.maxDuration = maxDuration;
//        }

//        public void Interpret(IContext context)
//        {
//            var unitToCssString = MeasurementUnitFactory
//                .GetMeasurementCssUnit(this.measurementUnit);
//            var durationToString = $"{duration}{unitToCssString}";
//            new NameExpression("animation").Interpret(context);
//            new ValueEqualitySign().Interpret(context);
//            context.Append(durationToString);
//            new Semicolon().Interpret(context);
//        }

//        private void ValidateTypeState(int outterDuration, MeasurementUnitType unit)
//        {
//            this.ValidateDuration(outterDuration);
//            this.ValidateUnit(unit);
//        }

//        private void ValidateDuration(int outterDuration)
//        {
//            if (outterDuration < this.minDuration && outterDuration > this.maxDuration)
//            {
//                throw new ArgumentOutOfRangeException(nameof(outterDuration));
//            }
//        }

//        private void ValidateUnit(MeasurementUnitType unit)
//        {
//            if (!this.validUnits.Any(ut => ut.Equals(unit)))
//            {
//                var validPossibilities = string.Join(", ", validUnits.Select(vu => vu.ToString()));
//                throw new ArgumentException(
//                    $"You pass invalid unit type, valid units are: {validPossibilities}");
//            }
//        }
//    }
//}