using System.Dynamic;

namespace TypeBuilders
{
    using System.Collections.ObjectModel;
    using System.Linq.Expressions;
    using System.Runtime.CompilerServices;

    public class Binder : CallSiteBinder, IDynamicMetaObjectProvider
    {
        public override Expression Bind(
            object[] args,
            ReadOnlyCollection<ParameterExpression> parameters,
            LabelTarget returnLabel)
        {
            throw new System.NotImplementedException();
        }

        public DynamicMetaObject GetMetaObject(Expression parameter)
        {
            var callConv = new CallConvThiscall();
            //CallSite<>
                /* BindDelegate()*/
            throw new System.NotImplementedException();
        }
    }
}