namespace Interpretators.Expressions.PropertyNames
{
    using Models.Enums;
    using Models.Factories;

    public abstract class PropertyName : IdentifierExpression<string>
    {
        protected PropertyName(
            CssPropertyType representation) : base(
                CssPropertyFactory.GetCssPropertyString(representation))
        {
        }
    }
}