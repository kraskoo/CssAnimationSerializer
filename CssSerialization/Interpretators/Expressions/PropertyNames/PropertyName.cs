namespace Interpretators.Expressions.PropertyNames
{
    using Models.Enums;
    using Models.Factories;

    public abstract class PropertyName : NameExpression<string>
    {
        protected PropertyName(
            CssPropertyType propertyType) : base(
                CssPropertyFactory.GetCssPropertyString(propertyType))
        {
        }
    }
}