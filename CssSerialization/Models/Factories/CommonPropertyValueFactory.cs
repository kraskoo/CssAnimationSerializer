namespace Models.Factories
{
    using System;
    using Common;
    using Enums;

    public class CommonPropertyValueFactory
    {
        private static readonly string WrongEnumTypeMessage = string.Format(
            "{0}{1}",
            "Unknown enum value type.",
            "You can try to extend the method with yours enum type, this supposed to works.");

        public static string GetAnyEnumAsCssString<T>(T enumValue)
        {
            var rotateY = TransformType.RotateY.Get();
            throw new ArgumentException(WrongEnumTypeMessage);
        }
    }
}