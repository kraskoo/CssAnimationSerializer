namespace Interfaces
{
    public interface INestedExpression
    {
        IExpression Nested(IExpression current, IExpression @in);
    }
}