namespace Models.Factories
{
    using System;
    using Enums;

    public class MeasurementUnitFactory
    {
        public static string GetMeasurementCssUnit(MeasurementUnitType measurementUnit)
        {
            switch (measurementUnit)
            {
                case MeasurementUnitType.None:
                    return string.Empty;
                case MeasurementUnitType.Centimeter:
                    return "cm";
                case MeasurementUnitType.Degree:
                    return "deg";
                // Relative to the font-size of the element (2em means 2 times the size of the current font)
                case MeasurementUnitType.Element:
                    return "em";
                case MeasurementUnitType.Inch:
                    return "in";
                case MeasurementUnitType.Millimeter:
                    return "mm";
                case MeasurementUnitType.Percentage:
                    return "%";
                case MeasurementUnitType.Pica:
                    return "pc";
                case MeasurementUnitType.Pixel:
                    return "px";
                case MeasurementUnitType.Point:
                    return "pt";
                case MeasurementUnitType.XHeightFontSize:
                    return "ex";
                case MeasurementUnitType.ViewPortHeight:
                    return "vh";
                case MeasurementUnitType.ViewPortWidth:
                    return "vw";
                case MeasurementUnitType.Millisecond:
                    return "ms";
                case MeasurementUnitType.Second:
                    return "s";
                default:
                    throw new ArgumentException("Unknown measurement unit type.");
            }
        }
    }
}