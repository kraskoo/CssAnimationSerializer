namespace Interpretators.Expressions.MeasurementUnits
{
    using Models.Enums;
    using Models.Factories;

    public abstract class MeasurementUnit : IdentifierExpression<string>
    {
        protected MeasurementUnit(
            MeasurementUnitType representation) : base(
                MeasurementUnitFactory.GetMeasurementCssUnit(representation))
        {
        }
    }
}