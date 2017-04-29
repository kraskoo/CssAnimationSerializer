namespace Interpretators.Expressions.PropertyValues
{
    using System;
    using Interfaces;
    using MeasurementUnits;
    using SyntaxParticularityValues;
    using Models.Enums;
    using System.Linq;

    public class DurationValueExpression : MultiplePropertyValueExpression<int>
    {
        private readonly int duration;
        private readonly int minDuration;
        private readonly int maxDuration;
        private readonly MeasurementUnit unitType;
        private readonly MeasurementUnitType[] validUnits =
        {
            MeasurementUnitType.Second,
            MeasurementUnitType.Millisecond
        };

        public DurationValueExpression(
            int duration,
            MeasurementUnit unitType,
            int minDuration = int.MinValue,
            int maxDuration = int.MaxValue) : base(
            duration, unitType, new ValueEqualitySign())
        {
            this.ValidateTypeState(duration, unitType.ToString());
            this.duration = duration;
            this.unitType = unitType;
            this.minDuration = minDuration;
            this.maxDuration = maxDuration;
        }

        public override void Interpret(IContext context)
        {
            context.Append($"{this.duration}");
            this.unitType.Interpret(context);
            new Semicolon().Interpret(context);
        }

        private void ValidateTypeState(int outterDuration, string unit)
        {
            this.ValidateDuration(outterDuration);
            this.ValidateUnit((MeasurementUnitType)Enum.Parse(typeof(MeasurementUnitType), unit));
        }

        private void ValidateDuration(int outterDuration)
        {
            if (outterDuration < this.minDuration && outterDuration > this.maxDuration)
            {
                throw new ArgumentOutOfRangeException(nameof(outterDuration));
            }
        }

        private void ValidateUnit(MeasurementUnitType unit)
        {
            if (!this.validUnits.Any(ut => ut.Equals(unit)))
            {
                var validPossibilities = string.Join(", ", validUnits.Select(vu => vu.ToString()));
                throw new ArgumentException(
                    $"You pass invalid unit type, valid units are: {validPossibilities}");
            }
        }
    }
}