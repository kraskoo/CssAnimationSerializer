namespace Models.Factories
{
    using System;
    using Enums;

    public class SyntaxParticularityFactory
    {
        public static string GetSynSyntaxParticularityCssString(SyntaxParticularityType type)
        {
            switch (type)
            {
                case SyntaxParticularityType.OpenBrace:
                    return "{";
                case SyntaxParticularityType.ValueEqualitySign:
                    return ": ";
                case SyntaxParticularityType.CloseBrase:
                    return "}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "Invalid syntax particularity type.");
            }
        }
    }
}