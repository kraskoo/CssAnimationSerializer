namespace Interpretators.Expressions
{
    using Interfaces;

    public class NameExpression : IdentifierExpression<string>
    {
        public NameExpression(
            string representation) : base(
                representation)
        {
        }

        public override void Interpret(IContext context)
        {
            context.Append(this.Representation);
        }
    }
}