namespace Interpretators.Expressions
{
    using Interfaces;

    public class SemicolonExpression : IdentifierExpression<char>
    {
        public SemicolonExpression() : base(';')
        {
        }

        public override void Interpret(IContext context)
        {
            context.Append($"{this.Representation}");
        }
    }
}