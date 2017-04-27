namespace Interpretators.Expressions.SyntaxParticularityValues
{
    using Models.Enums;
    using Models.Factories;

    public abstract class SyntaxParticularityValue : IdentifierExpression<string>
    {
        protected SyntaxParticularityValue(
            SyntaxParticularityType representation) : base(
                SyntaxParticularityFactory.GetSynSyntaxParticularityCssString(representation))
        {
        }
    }
}