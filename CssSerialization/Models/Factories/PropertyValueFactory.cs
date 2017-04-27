namespace Models.Factories
{
    using System;
    using Enums;

    public class PropertyValueFactory
    {
        public static string GetPropertyCssValue(PropertyValueTypes propertyValue)
        {
            switch (propertyValue)
            {
                case PropertyValueTypes.CubicBezier:
                    return "cubic-bezier";
                case PropertyValueTypes.Ease:
                    return "ease";
                case PropertyValueTypes.EaseIn:
                    return "ease-in";
                case PropertyValueTypes.EaseInOut:
                    return "ease-in-out";
                case PropertyValueTypes.EaseOut:
                    return "ease-out";
                case PropertyValueTypes.Inherit:
                    return "inherit";
                case PropertyValueTypes.Initial:
                    return "initial";
                case PropertyValueTypes.Linear:
                    return "linear";
                case PropertyValueTypes.StepEnd:
                    return "step-end";
                case PropertyValueTypes.StepStart:
                    return "step-start";
                case PropertyValueTypes.Steps:
                    return "steps";
                default:
                    throw new ArgumentException("Unknown type value.");
            }
        }
    }
}