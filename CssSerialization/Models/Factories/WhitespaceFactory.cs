namespace Models.Factories
{
    using System;
    using Enums;

    public class WhitespaceFactory
    {
        public static string GetWhitespaceCssString(WhitespaceType type)
        {
            switch (type)
            {
                case WhitespaceType.Space:
                    return " ";
                case WhitespaceType.Tab:
                    return "\t";
                case WhitespaceType.NewLine:
                    return Environment.NewLine;
                default:
                    throw new ArgumentOutOfRangeException(
                        nameof(type), type, "Invalid whitespace type.");
            }
        }
    }
}