namespace Interpretators.Expressions.Whitespaces
{
    using Models.Enums;
    using Models.Factories;

    public abstract class Whitespace : IdentifierExpression<string>
    {
        protected Whitespace(
            WhitespaceType representation) : base(
                WhitespaceFactory.GetWhitespaceCssString(representation))
        {
        }
    }
}